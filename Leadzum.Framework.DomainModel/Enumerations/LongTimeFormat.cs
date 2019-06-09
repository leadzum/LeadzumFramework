using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum LongTimeFormat
    {
        [Description("h:mm:ss tt")]
        LongTimeFormat1 = 1,
        [Description("hh:mm:ss tt")]
        LongTimeFormat2,
        [Description("H:mm:ss")]
        LongTimeFormat3,
        [Description("HH:mm:ss")]
        LongTimeFormat4
    }
}
