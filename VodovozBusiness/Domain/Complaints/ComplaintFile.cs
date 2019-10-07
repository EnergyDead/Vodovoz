﻿using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.HistoryLog;

namespace Vodovoz.Domain.Complaints
{
	[Appellative(Gender = GrammaticalGender.Neuter,
		NominativePlural = "приложения к жалобе",
		Nominative = "приложение к жалобе"
	)]
	[HistoryTrace]
	public class ComplaintFile : PropertyChangedBase, IDomainObject
	{
		public virtual int Id { get; set; }

		private string fileStorageId;
		[Display(Name = "Идентификатор файла в системе хранения")]
		public virtual string FileStorageId {
			get => fileStorageId;
			set => SetField(ref fileStorageId, value, () => FileStorageId);
		}

		private Complaint complaint;
		[Display(Name = "Жалоба")]
		public virtual Complaint Complaint {
			get => complaint;
			set => SetField(ref complaint, value, () => Complaint);
		}

		private ComplaintDiscussionComment complaintDiscussionComment;
		[Display(Name = "Комментарий к обсуждению жалобы")]
		public virtual ComplaintDiscussionComment ComplaintDiscussionComment {
			get => complaintDiscussionComment;
			set => SetField(ref complaintDiscussionComment, value, () => ComplaintDiscussionComment);
		}

		private byte[] byteFile;
		[Display(Name = "Файл")]
		public virtual byte[] ByteFile{
			get => byteFile;
			set => SetField(ref byteFile, value, () => ByteFile);
		}
	}
}
