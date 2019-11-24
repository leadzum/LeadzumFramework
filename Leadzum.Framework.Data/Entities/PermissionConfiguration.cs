using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leadzum.Framework.Data.Entities
{
    public partial class PermissionConfiguration : IEntityTypeConfigurationWithSeed<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasOne(p => p.Module).WithMany(m => m.Permissions)
           .HasForeignKey(r => r.ModuleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<Permission> builder)
        {

        }
    }
}
