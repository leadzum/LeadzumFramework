using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leadzum.Framework.Data.Entities
{
    public partial class PermissionConfiguration : IEntityTypeConfigurationWithSeed<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<Permission> builder)
        {

        }
    }
}
