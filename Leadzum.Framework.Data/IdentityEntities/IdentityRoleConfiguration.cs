using Leadzum.Framework.DomainModel.EnumerationAttributes;
using Leadzum.Framework.DomainModel.Enumerations;
using Leadzum.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public partial class IdentityRoleConfiguration : IEntityTypeConfigurationWithSeed<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.CreatedOnDate).IsRequired()
             .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.Property(p => p.LastModifiedOnDate).IsRequired()
            .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.HasMany(u => u.RolePermissions).WithOne(x => x.Role)
           .HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Claims).WithOne(x => x.Role)
            .HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserRoles).WithOne(x => x.Role)
           .HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityRole> builder)
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                builder.HasData(new IdentityRole { Id = (int)role, Name = role.GetDescription(), UserCategory = role.GetAttribute<UserCategoryAttribute, int>(), RoleCode = role.GetAttribute<KeyCodeAttribute>(), Description = role.GetDescription() });
            }
        }
    }
}
