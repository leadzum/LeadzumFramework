﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public class IdentityUserToken : IdentityUserToken<int>
    {
        public ApplicationUser User { get; set; }
    }
}
