using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leadzum.Framework.Data.Entities
{
    public partial class EventLogConfiguration : IEntityTypeConfigurationWithSeed<EventLog>
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            builder.Property(p => p.LogCreatedDate).IsRequired()
            .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<EventLog> builder)
        {
        }
    }
}
