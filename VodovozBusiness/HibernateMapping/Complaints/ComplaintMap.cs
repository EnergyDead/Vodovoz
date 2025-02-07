﻿using FluentNHibernate.Mapping;
using Vodovoz.Domain.Complaints;
using Vodovoz.Domain.Employees;

namespace Vodovoz.HibernateMapping.Complaints
{
	public class ComplaintMap : ClassMap<Complaint>
	{
		public ComplaintMap()
		{
			Table("complaints");

			OptimisticLock.Version();
			Version(x => x.Version).Column("version");

			Id(x => x.Id).Column("id").GeneratedBy.Native();

			Map(x => x.CreationDate).Column("creation_date");
			Map(x => x.ChangedDate).Column("changed_date");
			Map(x => x.ComplainantName).Column("complainant_name");
			Map(x => x.ComplaintText).Column("complaint_text");
			Map(x => x.Phone).Column("phone");
			Map(x => x.PlannedCompletionDate).Column("planned_completion_date");
			Map(x => x.Status).Column("status").CustomType<ComplaintStatusesStringType>();
			Map(x => x.ResultText).Column("result_text");
			Map(x => x.ComplaintType).Column("type").CustomType<ComplaintTypeStringType>();
			Map(x => x.ActualCompletionDate).Column("actual_completion_date");
			Map(x => x.Arrangement).Column("arrangement_text");
			Map(x => x.DriverRating).Column("driver_rating");

			References(x => x.CreatedBy).Column("created_by_id");
			References(x => x.ChangedBy).Column("changed_by_id");
			References(x => x.Counterparty).Column("counterparty_id");
			References(x => x.DeliveryPoint).Column("delivery_point_id");
			References(x => x.Order).Column("order_id");
			References(x => x.ComplaintSource).Column("complaint_source_id");
			References(x => x.ComplaintResultOfCounterparty).Column("complaint_result_of_counterparty_id");
			References(x => x.ComplaintResultOfEmployees).Column("complaint_result_of_employees_id");
			References(x => x.ComplaintKind).Column("complaint_kind_id");

			HasMany(x => x.Guilties).Cascade.AllDeleteOrphan().Inverse().LazyLoad().KeyColumn("complaint_id");
			HasMany(x => x.ComplaintDiscussions).Cascade.AllDeleteOrphan().Inverse().LazyLoad().KeyColumn("complaint_id");
			HasMany(x => x.Files).Cascade.AllDeleteOrphan().Inverse().LazyLoad().KeyColumn("complaint_id");

			HasManyToMany<Fine>(x => x.Fines)
				.Table("complaint_fines")
				.ParentKeyColumn("complaint_id")
				.ChildKeyColumn("fine_id")
				.LazyLoad();
		}
	}
}
