using Leadzum.Framework.DomainModel.EnumerationAttributes;
using Leadzum.Framework.DomainModel.Enumerations;
using Leadzum.Utility.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Leadzum.Framework.Data.Entities
{
    public partial class EventLogTypeConfiguration : IEntityTypeConfigurationWithSeed<EventLogType>
    {
        public void Configure(EntityTypeBuilder<EventLogType> builder)
        {
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<EventLogType> builder)
        {
            foreach (LogType logType in Enum.GetValues(typeof(LogType)))
            {
                builder.HasData(new EventLogType
                {
                    LogTypeId = (int)logType,
                    LogCategory = logType.GetAttribute<LogCategoryAttribute, int>(),
                    Key = logType.GetAttribute<KeyCodeAttribute>(),
                    FriendlyName = logType.GetDescription(),
                    LoggingIsActive = true
                });
            }
        }

    }
}
