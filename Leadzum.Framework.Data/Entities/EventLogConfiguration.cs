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

            builder.HasOne(u => u.EventLogType).WithMany(l => l.EventLogs)
           .HasForeignKey(r => r.LogTypeId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<EventLog> builder)
        {
        }
    }
}
