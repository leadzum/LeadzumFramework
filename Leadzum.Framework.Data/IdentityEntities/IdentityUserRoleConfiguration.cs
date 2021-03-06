﻿using Leadzum.Framework.DomainModel.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public partial class IdentityUserRoleConfiguration : IEntityTypeConfigurationWithSeed<IdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole> builder)
        {
            builder.HasOne(u => u.User).WithMany(x => x.Roles)
            .HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Role).WithMany(x => x.UserRoles)
           .HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<IdentityUserRole> builder)
        {
            //Assign role to superadmin
            builder.HasData(new IdentityUserRole { RoleId = (int)UserRole.SuperAdmin, UserId = 1 });
        }

    }
}
