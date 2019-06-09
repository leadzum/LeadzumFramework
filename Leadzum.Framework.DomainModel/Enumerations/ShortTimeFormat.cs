using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum ShortTimeFormat
    {
        [Description("h:mm tt")]
        ShortTimeFormat1 = 1,
        [Description("hh:mm tt")]
        ShortTimeFormat2,
        [Description("H:mm")]
        ShortTimeFormat3,
        [Description("HH:mm")]
        ShortTimeFormat4
    }
}
