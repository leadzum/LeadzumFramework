using Leadzum.Framework.DomainModel.EnumerationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Leadzum.Framework.DomainModel.Enumerations
{
    public enum UserRole
    {
        [KeyCode("SERVICE_CLIENT"), Description("Web Service Client"), UserCategory(UserCategory.WebServiceUser)]
        ServiceAdmin = 1,
        [KeyCode("SUPER_ADMIN"), Description("Super Admin"), UserCategory(UserCategory.SystemAdmin)]
        SuperAdmin=100,
        [KeyCode("ADMIN"), Description("Admin"), UserCategory(UserCategory.SystemAdmin)]
        Admin,
        [KeyCode("MEMBER"), Description("Member"), UserCategory(UserCategory.SystemUser)]
        Member = 200,       
    }
}
