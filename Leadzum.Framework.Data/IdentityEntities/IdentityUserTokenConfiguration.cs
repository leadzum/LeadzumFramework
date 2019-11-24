using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
     public partial class IdentityUserTokenConfiguration : IEntityTypeConfigurationWithSeed<IdentityUserToken>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken> builder)
        {
            builder.HasOne(u => u.User).WithMany(x => x.Tokens)
           .HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityUserToken> builder)
        {

        }
    }
}
