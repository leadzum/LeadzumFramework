using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
   public partial class IdentityUserLoginConfiguration : IEntityTypeConfigurationWithSeed<IdentityUserLogin>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin> builder)
        {
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityUserLogin> builder)
        {

        }
    }
}
