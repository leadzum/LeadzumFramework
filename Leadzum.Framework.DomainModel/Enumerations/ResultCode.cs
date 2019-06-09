using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum FuncResultCode
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("Success")]
        OK,
        [Description("Exception occurred")]
        Exception,
        [Description("No records found")]
        NoRecordsFound,
        [Description("Nothing updated")]
        NotUpdated,
        [Description("Record already exists")]
        RecordExists,
        [Description("Unable to connect to server")]
        WebServiceConnectionFailure,
        [Description("Unable to connect to database")]
        DatabaseConnectionFailure,
        [Description("Operation Cancelled")]
        OperationCancelled,
    }
}
