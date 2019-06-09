using Leadzum.Framework.DomainModel.EnumerationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum LogType
    {
        [KeyCode("LOGIN_SUCCESS"), Description("User Login Success"), LogCategory(LogCategory.AdminLog)]
        LoginSuccess = 1,
        [KeyCode("LOGIN_FAILURE"), Description("User Login Failure"), LogCategory(LogCategory.AdminLog)]
        LoginFailure,
        [KeyCode("LOGOUT"), Description("User Logout"), LogCategory(LogCategory.AdminLog)]
        Logout,
        [KeyCode("SYSTEM_CONFIG_UPDATED"), Description("System Configuration Updated"), LogCategory(LogCategory.AdminLog)]
        SystemConfigUpdated,
        [KeyCode("DATA_SYNCED"), Description("Data Synchronized"), LogCategory(LogCategory.AdminLog)]
        DataSynced,
        [KeyCode("USER_CREATED"), Description("New User Created"), LogCategory(LogCategory.AdminLog)]
        UserCreated,
        [KeyCode("USER_REGISTERED"), Description("New User Registered"), LogCategory(LogCategory.AdminLog)]
        UserRegistered,
        [KeyCode("USER_UPDATED"), Description("User Updated"), LogCategory(LogCategory.AdminLog)]
        UserUpdated,
        [KeyCode("USER_DELETED"), Description("User Deleted"), LogCategory(LogCategory.AdminLog)]
        UserDeleted,
        [KeyCode("USER_RESTORED"), Description("User Restored"), LogCategory(LogCategory.AdminLog)]
        UserRestored,
        [KeyCode("USER_REMOVED"), Description("User Removed"), LogCategory(LogCategory.AdminLog)]
        UserRemoved,
        [KeyCode("USER_PSW_CHANGED"), Description("User Password Changed"), LogCategory(LogCategory.AdminLog)]
        UserPswChanged,

        [KeyCode("ROLE_CREATED"), Description("New Role Created"), LogCategory(LogCategory.AdminLog)]
        RoleCreated,
        [KeyCode("ROLE_REGISTERED"), Description("Role Updated"), LogCategory(LogCategory.AdminLog)]
        RoleUpdated,
        [KeyCode("ROLE_DELETED"), Description("Role Deleted"), LogCategory(LogCategory.AdminLog)]
        RoleDeleted,

        [KeyCode("MODULE_CREATED"), Description("New Module Created"), LogCategory(LogCategory.AdminLog)]
        ModuleCreated,
        [KeyCode("MODULE_REGISTERED"), Description("Module Updated"), LogCategory(LogCategory.AdminLog)]
        ModuleUpdated,
        [KeyCode("MODULE_DELETED"), Description("Module Deleted"), LogCategory(LogCategory.AdminLog)]
        ModuleDeleted,


        [KeyCode("TASK_SCHEDULER_START"), Description("Task Scheduler Started"), LogCategory(LogCategory.MaintenanceLog)]
        TaskSchedulerStart = 1000,
        [KeyCode("TASK_SCHEDULER_STOP"), Description("Task Scheduler Stopped"), LogCategory(LogCategory.MaintenanceLog)]
        TaskSchedulerStop,

        [KeyCode("GENERAL_EXCEPTION"), Description("General Exception"), LogCategory(LogCategory.ExceptionLog)]
        GeneralException = 2000,
        [KeyCode("WEB_SERVICE_EXCEPTION"), Description("Web Service Exception"), LogCategory(LogCategory.ExceptionLog)]
        WebServiceException,
        [KeyCode("TASK_SCHEDULER_EXCEPTION"), Description("Task Scheduler Exception"), LogCategory(LogCategory.ExceptionLog)]
        TaskSchedulerException,
        [KeyCode("DB_EXCEPTION"), Description("Database Exception"), LogCategory(LogCategory.ExceptionLog)]
        DbException,
    }

}
