using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum ModuleType
    {
        Menu = 1,
        Tab = 1,
        Action = 3,
        Option = 4, //Filtering options allowed only when the perssion is assigned.
    }
}
