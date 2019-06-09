using Leadzum.Framework.DomainModel.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leadzum.Framework.Data.Entities
{
    public partial class ModuleConfiguration : IEntityTypeConfigurationWithSeed<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.Property(p => p.CreatedOnDate).IsRequired()
           .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");

            builder.Property(p => p.LastModifiedOnDate).IsRequired()
            .HasColumnType("DateTime").HasDefaultValueSql("GetDate()");
            Seed(builder);
        }
        public void Seed(EntityTypeBuilder<Module> builder)
        {
            int? parentId = null;
            int index = 0;
            int moduleId = 1;
            builder.HasData(
                new Module { ModuleId = moduleId++, Code = "DASHBOARD", Name = "Dashboard", Type = (int)ModuleType.Menu, Description="Dashboard", Url = "Home/Index", IconFile = "fa fa-tachometer", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ADMIN_USER_AND_PERMISSIOIN", Name = "User & Permission", Type = (int)ModuleType.Menu, Description = "User, role and permission management", Url = "", IconFile = "fa fa-users", ParentId = parentId, ViewOrder = ++index, IsClickable = false },
                new Module { ModuleId = moduleId++, Code = "ADMIN_SYSTEM", Name = "System", Type = (int)ModuleType.Menu, Description = "System configuration", Url = "", IconFile = "fa fa-cogs", ParentId = parentId, ViewOrder = ++index, IsClickable = false }
            );

            parentId = 2;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++ /*4*/, Code = "ADMIN_USER_MANAGEMENT", Name = "Users", Type = (int)ModuleType.Menu, Description = "User management", Url = "Admin/User/Index", IconFile = "fa fa-tachometer", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++ /*5*/, Code = "ADMIN_ROLE_MANAGEMENT", Name = "Roles", Type = (int)ModuleType.Menu, Description = "Role management", Url = "Admin/Role/Index", IconFile = "fa fa-users", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++ /*6*/, Code = "ADMIN_PERMISSION_MANAGEMENT", Name = "Permissions", Type = (int)ModuleType.Menu, Description = "Permission management", Url = "Admin/Permission/Index", IconFile = "fa fa-cogs", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 3;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++ /*7*/, Code = "ADMIN_SYSTEM_CONFIG", Name = "Configuration", Type = (int)ModuleType.Menu, Description = "System configuration", Url = "Admin/System/Index", IconFile = "fa fa-tachometer", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++ /*8*/, Code = "ADMIN_SYSTEM_MODULE", Name = "Modules", Type = (int)ModuleType.Menu, Description = "System module management", Url = "Admin/Moudle/Index", IconFile = "fa fa-users", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++ /*9*/, Code = "ADMIN_SYSTEM_AUDIT", Name = "Audit Logs", Type = (int)ModuleType.Menu, Description = "System audit logs", Url = "Admin/Audit/Index", IconFile = "fa fa-cogs", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 7;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++ /*10*/, Code = "ADMIN_SYSTEM_GENERAL", Name = "General", Type = (int)ModuleType.Menu, Description = "System general settings", Url = "Admin/System/General", IconFile = "fa fa-tachometer", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++ /*11*/, Code = "ADMIN_SYSTEM_ADVANCED", Name = "Advanced", Type = (int)ModuleType.Menu, Description = "System advanced settings", Url = "Admin/System/Advanced", IconFile = "fa fa-users", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 10;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++, Code = "ACTION_SYSTEM_GENERAL_EDIT", Name = "Edit", Type = (int)ModuleType.Menu, Description = "Edit system general settings", Url = "Admin/System/GeneralEdit", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 11;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++, Code = "ACTION_SYSTEM_ADVANCED_EDIT", Name = "Edit", Type = (int)ModuleType.Menu, Description = "Edit system advanced settings", Url = "Admin/System/AdvancedEdit", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 4;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++, Code = "ACTION_USER_ADD", Name = "Add User", Type = (int)ModuleType.Action, Description = "Add User", Url = "Admin/User/Add", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_USER_EDIT", Name = "Edit User", Type = (int)ModuleType.Action, Description = "Edit User", Url = "Admin/User/Edit", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_USER_DELETE", Name = "Delete User", Type = (int)ModuleType.Action, Description = "Delete User", Url = "Admin/User/Delete", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 5;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++, Code = "ACTION_ROLE_ADD", Name = "Add Role", Type = (int)ModuleType.Action, Description = "Add Role", Url = "Admin/Role/Add", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_ROLE_EDIT", Name = "Edit Role", Type = (int)ModuleType.Action, Description = "Edit Role", Url = "Admin/Role/Edit", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_ROLE_DELETE", Name = "Delete Role", Type = (int)ModuleType.Action, Description = "Delete Role", Url = "Admin/Role/Delete", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 6;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++, Code = "ACTION_PERMISSION_ADD", Name = "Add Permission", Type = (int)ModuleType.Action, Description = "Add Permission", Url = "Admin/Permission/Add", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_PERMISSION_EDIT", Name = "Edit Permission", Type = (int)ModuleType.Action, Description = "Edit Permission", Url = "Admin/Permission/Edit", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_PERMISSION_DELETE", Name = "Delete Permission", Type = (int)ModuleType.Action, Description = "Delete Permission", Url = "Admin/Permission/Delete", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );

            parentId = 8;
            index = 0;
            builder.HasData(
                new Module { ModuleId = moduleId++, Code = "ACTION_MODULE_ADD", Name = "Add Module", Type = (int)ModuleType.Action, Description = "Add Module", Url = "Admin/Module/Add", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_MODULE_EDIT", Name = "Edit Module", Type = (int)ModuleType.Action, Description = "Edit Module", Url = "Admin/Module/Edit", ParentId = parentId, ViewOrder = ++index, IsClickable = true },
                new Module { ModuleId = moduleId++, Code = "ACTION_MODULE_DELETE", Name = "Delete Module", Type = (int)ModuleType.Action, Description = "Delete Module", Url = "Admin/Module/Delete", ParentId = parentId, ViewOrder = ++index, IsClickable = true }
            );
        }
    }
}
