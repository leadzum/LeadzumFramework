using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public partial class IdentityUserClaimConfiguration : IEntityTypeConfigurationWithSeed<IdentityUserClaim>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim> builder)
        {
            builder.HasOne(p => p.User).WithMany(m => m.Claims)
           .HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityUserClaim> builder)
        {

        }
    }
}
