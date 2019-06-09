using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum DateFormat
    {
        [Description("yyyy-MM-dd")]
        DateFormat1 = 1,
        [Description("M/d/yyyy")]
        DateFormat2,
        [Description("MM/dd/yyyy")]
        DateFormat3,
        [Description("MMM d, yyyy")]
        DateFormat4,
        [Description("MMM dd, yyyy")]
        DateFormat5,
        [Description("d/M/yyyy")]
        DateFormat6,
        [Description("dd/MM/yyyy")]
        DateFormat7,
        [Description("d MMM, yyyy")]
        DateFormat8,
        [Description("dd MMM, yyyy")]
        DateFormat9,
        [Description("dd-MMM-yyyy")]
        DateFormat10,
    }
}
