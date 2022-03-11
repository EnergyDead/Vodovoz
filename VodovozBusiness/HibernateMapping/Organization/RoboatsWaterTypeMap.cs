﻿using FluentNHibernate.Mapping;
using Vodovoz.Domain.Organizations;
namespace Vodovoz.HibernateMapping.Organization
{
	public class RoboatsWaterTypeMap : ClassMap<RoboatsWaterType>
	{
		public RoboatsWaterTypeMap()
		{
			Table("roboats_water_types");

			Id(x => x.Id).GeneratedBy.Native();

			References(x => x.Nomenclature).Column("nomenclature_id");
			Map(x => x.RoboatsAudiofile).Column("audio_filename");
			Map(x => x.FileId).Column("file_id");
		}
	}
}
