﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BitrixApi.DTO;
using BitrixApi.REST;
using Newtonsoft.Json;
using QS.DomainModel.UoW;
using Vodovoz.Domain;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories;
using VodovozInfrastructure.Utils;

namespace BitrixIntegration {
    public class DealCollector 
	{
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IBitrixRestApi bitrixApi;
        private readonly IDealFromBitrixRepository dealFromBitrixRepository;
        private const int BITRIXRESTRICTION = 50;

        public DealCollector(IBitrixRestApi _bitrixRestApi, IDealFromBitrixRepository _dealFromBitrixRepository)
        {
            bitrixApi = _bitrixRestApi ?? throw new ArgumentNullException(nameof(_bitrixRestApi));
            dealFromBitrixRepository = _dealFromBitrixRepository ?? throw new ArgumentNullException(nameof(_dealFromBitrixRepository));
        }


        public async Task<IList<Deal>> CollectDeals(IUnitOfWork uow, DateTime day, bool checkFailed)
        {
			throw new NotImplementedException();
            ////Вот тут будет нахождение всех нужных сделок в зависимости от флага
            //var startDate = day.StartOfDay();
            //var endDate = day.EndOfDay();
            //var listOfIds = await bitrixApi.GetDealsIdsBetweenDates(startDate, endDate);
            //if (checkFailed) return await CollectDeals(uow, listOfIds);
            
            ///*var failedDeals = dealFromBitrixRepository.GetAllFailed(uow, startDate, endDate);
            //listOfIds = FilterFailedDealsFromList(listOfIds, failedDeals);*/
            ////Теперь listOfIds отфильтрованы зафейленными
            //return await CollectDeals(uow, listOfIds);
        }
		/*
        IList<uint> FilterFailedDealsFromList(IList<uint> listOfIds, IList<DealFromBitrix>  failedDeals)
        {
            // Отфильтруем уже зафейленные
            var filteredFromFailedDeals = listOfIds.Where(x => failedDeals.All(failed => failed.BitrixId != x));
            var notFailedDeals = filteredFromFailedDeals as uint[] ?? filteredFromFailedDeals.ToArray();
            logger.Info($"Отфильтровано {failedDeals.Count - notFailedDeals.Length} зафейленных сделок");
            return notFailedDeals;
        }
		*/
        
        public async Task<IList<Deal>> CollectDeals(IUnitOfWork uow, IList<uint> dealsIds)
        {
            // А вот тут уже только обработка полученных сделок, которым могут быть как отфильтрованными так и нет
            uint j = 0;
            Dictionary<uint, string> failedIdToExeprion = new Dictionary<uint, string>();
            IList<Deal> listOfdeals = new List<Deal>();
            foreach (var dealId in dealsIds){
                Deal deal = null;
                try{
                    deal = await bitrixApi.GetDealAsync(dealId);
                }
                catch (JsonSerializationException e){
                    
                    #region Нет периода доставки

                    if (e.Message.Contains("UF_CRM_5DA9BBA03A12A")){
                        string exceptionText = 
                            $"Сделка с id: {dealId} не содержит периода доставки, " +
                            $"скорее всего это сделка появилась в битриксе не из CRM, " +
                            $"а была добавлена из ДВ в виде подтверждения оплдаты по СМС, " +
                            $"эта сделка не должна была сюда попасть (выборка по сделкам со статусом завести в ДВ)";
                        logger.Warn(exceptionText);
                        SendFailedDealFromBitrixToDB(uow, dealId, exceptionText);
                    }

                    #endregion
                    
                    else{
                        failedIdToExeprion[dealId] = e.ToString();
                    }
                    j++;
                    continue;
                }
                catch (HttpRequestException e){
                    if (e.Message.Contains("400 (Bad Request)")){
                        string exeption = $"Сделка с id: {dealId} не найдена в системе битрикс";
                        logger.Warn(exeption);
                        SendFailedDealFromBitrixToDB(uow, dealId, exeption);
                    }
                    else{
                        failedIdToExeprion[dealId] = e.ToString();
                    }
                    j++;
                    continue;
                }
                catch (Exception e){
                    failedIdToExeprion[dealId] = e.ToString();
                    j++;
                    continue;
                }
                
                listOfdeals.Add(deal);
                
                if (j  == BITRIXRESTRICTION){
                    Thread.Sleep(1000);
                    j = 0;
                }
                j++;
            }
            logger.Info($"Десериализовано: {listOfdeals.Count} сделок\n" +
                        $"не отправленных в базу ошибок: {failedIdToExeprion.Count}\n");

            int errCounter = 1;
            foreach (var keyValuePair in failedIdToExeprion){
                logger.Info($"Отправка ошибки номер: {errCounter++}");
                SendFailedDealFromBitrixToDB(uow, keyValuePair.Key, keyValuePair.Value);
            }
            if (errCounter > 1)
                logger.Info("Ошибки отправлены");
            
            return listOfdeals;
        }
        
        public void SendFailedDealFromBitrixToDB(IUnitOfWork uow, uint dealId, string exсeption)
        {
            var deal = dealFromBitrixRepository.GetByBitrixId(uow, dealId);
            if (deal != null){
                logger.Info($"Сделка {dealId} уже была добавлена как обработанная с ошибкой, обновление...");
                deal.Success = false;
                deal.ProcessedDate = DateTime.Now;
                deal.ExtensionText = exсeption;
                try{
                    uow.Save(deal);
                    uow.Commit();
                }
                catch (Exception exception){
                    logger.Error($"!Ошибка при отправке обновленной ошибочной сделки {dealId}\n{exception.Message}\n{exception?.InnerException}");
                }
            }
            else{
                deal = new DealFromBitrix(){
                    Success = false,
                    BitrixId = dealId,
                    CreateDate = DateTime.Now,
                    ExtensionText = exсeption
                };
                try{
                    uow.Save(deal);
                    uow.Commit();
                }
                catch (Exception exception){
                    if (exception.InnerException != null && exception.InnerException.Message.Contains("Duplicate entry")){
                        logger.Error($"Ошибка о том что сделка: {dealId} не обработана уже отправлена в базу deals_from_bitrix");
                    }
                    else {
                        logger.Error($"!Ошибка при отправке ошибочной сделки {dealId}\n{exception.Message}\n{exception?.InnerException}");
                    }
                }
            }
        }
        
        public async Task SendSuccessDealFromBitrixToDB(IUnitOfWork uow, uint dealId, Order order)
        {
            var deal = dealFromBitrixRepository.GetByBitrixId(uow, dealId);
            if(deal != null) {
                logger.Info($"Обновление существующей сделки {deal.Id} на успешную");
                deal.Success = true;
                deal.ProcessedDate = DateTime.Now;
                deal.ExtensionText = null;
                try{
                    uow.Save(deal);
                    uow.Commit();
                }
                catch (Exception exception){
                    logger.Error($"!Ошибка при отправке обновленной успешной(ранее ошибочной) сделки {deal.Id}\n{exception.Message}\n{exception?.InnerException}");
                }
            } else {
                deal = new DealFromBitrix() {
                    Success = true,
                    BitrixId = dealId,
                    Order = order,
                    CreateDate = DateTime.Now,
                    ProcessedDate = DateTime.Now
                };
                try{
                    uow.Save(deal); 
                    uow.Commit();
                    var attemptCounts = 0;
                    var statusUpdated = false;
                    /*do {
                        Thread.Sleep(500);
                        statusUpdated = await bitrixApi.SendWONBitrixStatus(dealId);
                    } while(!statusUpdated && attemptCounts < 3);*/

                    if(statusUpdated) {
                        logger.Info($"Статус сделки {dealId} успешно обновлен в битриксе");
                    }
                    else {
                        logger.Error($"Статус сделки {dealId} не удалось обновить в битриксе" +
                                     ", но в ДВ успешно сохранена");
                    }
                }
                catch (Exception exception){
                    if (exception.InnerException != null && exception.InnerException.Message.Contains("Duplicate entry")){
                        logger.Error($"Сделка {dealId} уже обработана");
                    }
                    else
                        logger.Error($"!Ошибка при отправке успешной сделки {dealId}\n{exception.Message}\n{exception?.InnerException}");
                }
            }
        }
    }
}