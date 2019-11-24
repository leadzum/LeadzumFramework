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

            builder.HasOne(u => u.Role).WithMany(p => p.RolePermissions)
            .HasForeignKey(r => r.RoleId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.User).WithMany(p => p.Permissions)
           .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(u => u.Permission).WithMany(p => p.RolePermissions)
           .HasForeignKey(r => r.PermissionId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<RolePermission> builder)
        {

        }
    }
}
