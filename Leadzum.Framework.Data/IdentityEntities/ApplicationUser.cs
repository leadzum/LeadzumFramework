using Leadzum.Framework.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required, MaxLength(256)]
        public string DisplayName { get; set; }

        public int UserTypeId { get; set; }

        [DefaultValue(0)]
        public int PasswordChangeStatus { get; set; }

        [DefaultValue(true)]
        [Required]
        public bool IsAuthorized { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

          public int? CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int? LastModifiedByUserId { get; set; }

        public DateTime LastModifiedOnDate { get; set; }

        public virtual ICollection<IdentityUserRole> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin> Logins { get; set; }

        public virtual ICollection<IdentityUserToken> Tokens { get; set; }

        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
