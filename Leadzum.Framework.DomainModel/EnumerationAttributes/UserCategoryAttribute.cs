using Leadzum.Framework.DomainModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.DomainModel.EnumerationAttributes
{
    public class UserCategoryAttribute : Attribute
    {
        public UserCategoryAttribute(UserCategory category)
        {
            Category = category;
        }

        public UserCategory Category { get; private set; }

        public override object TypeId
        {
            get
            {
                return Category;
            }
        }
    }
}
