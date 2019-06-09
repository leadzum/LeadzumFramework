using Leadzum.Framework.Data.Entities;
using Leadzum.Framework.Data.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leadzum.Framework.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, int, IdentityUserClaim, IdentityUserRole, IdentityUserLogin, IdentityRoleClaim, IdentityUserToken>
    {
        #region DataSet
        public DbSet<SystemConfig> SystemConfigs { get; set; } // SystemConfig
        public DbSet<List> Lists { get; set; } // Lists
        public DbSet<EventLogType> EventLogTypes { get; set; } // EventLogType
        public DbSet<EventLog> EventLogs { get; set; } // EventLog
        public DbSet<Module> Modules { get; set; } // Module
        public DbSet<Permission> Permissions { get; set; } // Permission
        public DbSet<RolePermission> RolePermissions { get; set; } // RolePermission
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Rename .NET Core Identity Tables 
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var table = entityType.Relational().TableName;
                if (table.StartsWith("AspNet"))
                {
                    entityType.Relational().TableName = table.Substring("AspNet".Length);
                }
            };
            //.NET Core Identity
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new IdentityUserClaimConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
            builder.ApplyConfiguration(new IdentityRoleClaimConfiguration());
            builder.ApplyConfiguration(new IdentityUserLoginConfiguration());
            builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
            builder.ApplyConfiguration(new IdentityUserTokenConfiguration());

            builder.ApplyConfiguration(new SystemConfigConfiguration());
            builder.ApplyConfiguration(new ListConfiguration());
            builder.ApplyConfiguration(new EventLogTypeConfiguration());
            builder.ApplyConfiguration(new EventLogConfiguration());
            builder.ApplyConfiguration(new ModuleConfiguration());
            builder.ApplyConfiguration(new PermissionConfiguration());
            builder.ApplyConfiguration(new RolePermissionConfiguration());

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
