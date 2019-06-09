using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.DomainModel.EnumerationAttributes
{
    public class KeyCodeAttribute : Attribute
    {
        public KeyCodeAttribute(string keyCode)
        {
            KeyCode = keyCode;
        }

        public string KeyCode { get; private set; }

        public override object TypeId
        {
            get
            {
                return KeyCode;
            }
        }
    }
}
