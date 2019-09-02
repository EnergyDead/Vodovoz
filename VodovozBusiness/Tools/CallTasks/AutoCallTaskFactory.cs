﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Bindings.Utilities;
using System.Linq;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories.CallTasks;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.Services;

namespace Vodovoz.Tools.CallTasks
{
	public class AutoCallTaskFactory : IAutoCallTaskFactory , IDisposable
	{
		private Order order;
		public virtual Order Order {
			get { return order; }
			set {
				if(value == null && order != null)
					order.OnOrderStatusChanged -= UpdateAutoGeneratedTasks;
				order = value; 
				ConfigureOrderChangeHeandlers(); 
			}
		}

		public ITaskCreationInteractive TaskCreationInteractive { get; set; }

		private ICallTaskFactory callTaskFactory { get;}
		private ICallTaskRepository callTaskRepository { get;}
		private IOrderRepository orderRepository { get;}
		private IEmployeeRepository employeeRepository { get;}
		private IPersonProvider personProvider { get;}

		public AutoCallTaskFactory(ICallTaskFactory callTaskFactory, ICallTaskRepository callTaskRepository, IOrderRepository orderRepository, IEmployeeRepository employeeRepository, IPersonProvider personProvider)
		{
			this.callTaskFactory = callTaskFactory ?? throw new ArgumentNullException(nameof(callTaskFactory));
			this.callTaskRepository = callTaskRepository ?? throw new ArgumentNullException(nameof(callTaskRepository));
			this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
			this.personProvider = personProvider ?? throw new ArgumentNullException(nameof(personProvider));
		}

		private void ConfigureOrderChangeHeandlers()
		{
			if(order == null)
				return;
			order.OnOrderStatusChanged += UpdateAutoGeneratedTasks;
		}

		private void UpdateAutoGeneratedTasks(OrderStatus orderStatus)
		{
			switch(orderStatus) 
			{
				case OrderStatus.Accepted: UpdateCallTask();
					break;
				case OrderStatus.Shipped: UpdateDepositReturnTask();
					break;
				case OrderStatus.DeliveryCanceled: TryDeleteTask();
					break;
			}
		}

		private bool UpdateCallTask()
		{
			DateTime? dateTime = null;
			if(TaskCreationInteractive != null)
				if(TaskCreationInteractive.RunQuestion(ref dateTime) == CreationTaskResult.Cancel)
					return false;

			IEnumerable<CallTask> tasks;

			if(order.SelfDelivery)
				tasks = callTaskRepository.GetActiveSelfDeliveryTaskByCounterparty(order.UoW, order.Client, CallTaskStatus.Call);
			else
				tasks = callTaskRepository.GetActiveTaskByDeliveryPoint(order.UoW, order.DeliveryPoint, CallTaskStatus.Call);

			if(tasks?.FirstOrDefault() == null)
				return false;

			if(dateTime == null) {
				int? ordersCount;
				double dif = orderRepository.GetAvgRandeBetwenOrders(order.UoW, order.DeliveryPoint, out ordersCount);
				dateTime = (ordersCount.HasValue && ordersCount.Value >= 3) ? order.DeliveryDate.Value.AddDays(dif) : DateTime.Now.AddMonths(1);
			}

			var newTask = new CallTask();
			callTaskFactory.FillNewTask(order.UoW, newTask, employeeRepository);
			newTask.AssignedEmployee = tasks?.OrderBy(x => x.EndActivePeriod).LastOrDefault().AssignedEmployee;
			newTask.TaskState = CallTaskStatus.Call;
			newTask.DeliveryPoint = order.DeliveryPoint;
			newTask.Counterparty = order.Client;
			newTask.EndActivePeriod = dateTime.Value;
			newTask.SourceDocumentId = order.Id;
			newTask.Source = TaskSource.AutoFromOrder;
			order.UoW.Save(newTask);

			if(tasks?.FirstOrDefault() != null) {
				foreach(var item in tasks) {
					item.IsTaskComplete = true;
					string comment = $"Автоперенос задачи на {dateTime?.ToString("dd / MM / yyyy")}";
					item.AddComment(order.UoW, comment);
					order.UoW.Save(item);
				}
			}

			return true;
		}

		private bool UpdateDepositReturnTask()
		{
			bool createTask = false;
			var equipmentToClient = order.OrderEquipments.Where(x => x.Direction == Direction.Deliver);
			var equipmentFromClient = order.OrderEquipments.Where(x => x.Direction == Direction.PickUp);

			foreach(var item in equipmentToClient) {
				if(!equipmentFromClient.Any(x => x.Nomenclature.Id == item.Nomenclature.Id))
					createTask = true;
			}


			if(!createTask)
				return false;
				
			CallTask activeTask;

			if(order.SelfDelivery)
				activeTask = callTaskRepository.GetActiveSelfDeliveryTaskByCounterparty(order.UoW, order.Client, CallTaskStatus.DepositReturn, 1)?.FirstOrDefault();
			else
				activeTask = callTaskRepository.GetActiveTaskByDeliveryPoint(order.UoW, order.DeliveryPoint, CallTaskStatus.DepositReturn, 1)?.FirstOrDefault();

			if(activeTask != null)
				return false;

			var newTask = new CallTask();	
			callTaskFactory.FillNewTask(order.UoW, newTask, employeeRepository);
			newTask.AssignedEmployee = personProvider.GetDefaultEmployeeForDepositReturnTask(order.UoW);
			newTask.TaskState = CallTaskStatus.DepositReturn;
			newTask.DeliveryPoint = order.DeliveryPoint;
			newTask.Counterparty = order.Client;
			newTask.EndActivePeriod = DateTime.Now.Date.AddHours(23).AddMinutes(59);
			newTask.SourceDocumentId = order.Id;
			newTask.Source = TaskSource.AutoFromOrder;
			order.UoW.Save(newTask);

			return true;
		}

		private bool TryDeleteTask()
		{
			var tasks = callTaskRepository.GetAutoGeneratedTask(order.UoW, order, CallTaskStatus.DepositReturn);

			if(tasks?.FirstOrDefault() == null)
				return false;

			foreach(var item in tasks)
				order.UoW.Delete(item);

			return true;
		}

		public void Dispose()
		{
			order.CallTaskAutoFactory = null;
		}
	}
}
