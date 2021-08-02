﻿using System;
using System.Data.Bindings.Collections.Generic;
using System.IO;
using QS.Commands;
using QS.ViewModels;
using Vodovoz.Domain.Complaints;
using System.Diagnostics;
using QS.Dialog;
using QS.DomainModel.UoW;
using QS.Project.Services;
using QS.Services;
using Vodovoz.EntityRepositories;

namespace Vodovoz.ViewModels
{
	public class FilesViewModel : UoWWidgetViewModelBase
	{
		private readonly IInteractiveService _interactiveService;
		private readonly IFilePickerService _filePicker;

		private GenericObservableList<ComplaintFile> filesList;
		public virtual GenericObservableList<ComplaintFile> FilesList {
			get => filesList;
			set => SetField(ref filesList, value, () => FilesList);
		}

		private bool readOnly;
		public virtual bool ReadOnly {
			get => readOnly;
			set => SetField(ref readOnly, value);
		}

		#region Commands

		public DelegateCommand AddItemCommand { get; private set; }
		public DelegateCommand<ComplaintFile> OpenItemCommand { get; private set; }
		public DelegateCommand<ComplaintFile> DeleteItemCommand { get; private set; }
		public DelegateCommand<ComplaintFile> LoadItemCommand { get; private set; }

		public FilesViewModel(IFilePickerService filePicker, IInteractiveService interactiveService, IUnitOfWork uow)
		{
			_interactiveService = interactiveService ?? throw new ArgumentNullException(nameof(interactiveService));
			_filePicker = filePicker ?? throw new ArgumentNullException(nameof(filePicker));
			UoW = uow ?? throw new ArgumentNullException(nameof(uow));
			CreateCommands();
		}

		private void CreateCommands()
		{
			AddItemCommand = new DelegateCommand(
				() => {

					if(_filePicker.OpenSelectFilePicker(out string filePath)) 
					{
						var complaintFile = new ComplaintFile();
						complaintFile.FileStorageId = Path.GetFileName(filePath);
						
						if (complaintFile.FileStorageId.Length > 45) {
							_interactiveService.ShowMessage(
								ImportanceLevel.Warning,
								"Слишком длинное имя файла.\n" +
								"Оно не должно превышать 45 символов, включая расширение (.txt, .png и т.д.).");
							return;
						}

						complaintFile.ByteFile = File.ReadAllBytes(filePath);

						if(FilesList == null)
							FilesList = new GenericObservableList<ComplaintFile>();
						FilesList.Add(complaintFile);
					}
				},
				() => !ReadOnly);

			DeleteItemCommand = new DelegateCommand<ComplaintFile>(
				file => { FilesList.Remove(file); },
				file => !ReadOnly);

			OpenItemCommand = new DelegateCommand<ComplaintFile>(
				file => {

					var vodUserTempDir = UserSingletonRepository.GetInstance().GetTempDirForCurrentUser(UoW);

					if(string.IsNullOrWhiteSpace(vodUserTempDir))
						return;

					var tempFilePath = Path.Combine(Path.GetTempPath(),vodUserTempDir, file.FileStorageId);

					if(!File.Exists(tempFilePath))
						File.WriteAllBytes(tempFilePath, file.ByteFile);

					var process = new Process();
					process.StartInfo.FileName = Path.Combine(vodUserTempDir, file.FileStorageId);
					process.Start();
				});

			LoadItemCommand = new DelegateCommand<ComplaintFile>(
				file => {
					if(_filePicker.OpenSaveFilePicker(file.FileStorageId, out string filePath))
						File.WriteAllBytes(filePath, file.ByteFile);
				},
				file => !ReadOnly);
		}

		#endregion Commands
	}
}
