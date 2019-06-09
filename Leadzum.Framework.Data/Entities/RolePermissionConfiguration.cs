using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leadzum.Framework.Data.Entities
{
    public partial class RolePermissionConfiguration : IEntityTypeConfigurationWithSeed<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.Property(p => p.CreatedOnDate).IsRequired()
           .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.Property(p => p.LastModifiedOnDate).IsRequired()
            .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<RolePermission> builder)
        {

        }
    }
}
