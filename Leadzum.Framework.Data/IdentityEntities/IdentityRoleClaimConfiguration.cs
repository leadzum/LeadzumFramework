using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public partial class IdentityRoleClaimConfiguration : IEntityTypeConfigurationWithSeed<IdentityRoleClaim>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim> builder)
        {
            builder.HasOne(p => p.Role).WithMany(m => m.Claims)
           .HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityRoleClaim> builder)
        {
        }
    }
}
