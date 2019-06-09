using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum LogCategory
    {
        [Description("Admin Log")]
        AdminLog = 1,
        [Description("Maintenance Log")]
        MaintenanceLog,
        [Description("Exception Log")]
        ExceptionLog
    }
}
