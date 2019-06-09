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
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityRoleClaim> builder)
        {
        }
    }
}
