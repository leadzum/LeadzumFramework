using Leadzum.Framework.DomainModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.DomainModel.EnumerationAttributes
{
    public class LogCategoryAttribute : Attribute
    {
        public LogCategoryAttribute(LogCategory category)
        {
            Category = category;
        }

        public LogCategory Category { get; private set; }

        public override object TypeId
        {
            get
            {
                return Category;
            }
        }
    }
}
