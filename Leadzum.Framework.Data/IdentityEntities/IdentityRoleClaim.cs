﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public class IdentityRoleClaim : IdentityRoleClaim<int>
    {
        public IdentityRole Role { get; set; }
    }
}
