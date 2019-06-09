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
