using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
     public partial class IdentityUserTokenConfiguration : IEntityTypeConfigurationWithSeed<IdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole> builder)
        {
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityUserRole> builder)
        {

        }
    }
}
