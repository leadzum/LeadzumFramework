using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public partial class ApplicationUserConfiguration : IEntityTypeConfigurationWithSeed<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(p => p.UserName).IsUnique();

            builder.Property(p => p.CreatedOnDate).IsRequired()
             .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.Property(p => p.LastModifiedOnDate).IsRequired().
            HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.HasMany(u => u.Roles).WithOne(x=>x.User)
            .HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Claims).WithOne(x => x.User)
            .HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Logins).WithOne(x => x.User)
           .HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Tokens).WithOne(x => x.User)
           .HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Permissions).WithOne(x => x.User)
            .HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<ApplicationUser> builder)
        {
            var passwordHash = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                Id = 1,
                UserName = "superadmin@mail.com",
                NormalizedUserName = "SUPERADMIN@MAIL.COM",
                DisplayName = "Super Admin",
                Email = "superadmin@mail.com",
                NormalizedEmail = "SUPERADMIN@MAIL.COM",
                PasswordHash = passwordHash.HashPassword(null, "P@ssw0rd"),
                SecurityStamp = string.Empty,
            };
            builder.HasData(user);
        }
    }
}
