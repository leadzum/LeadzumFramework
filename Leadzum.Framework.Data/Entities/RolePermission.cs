using Leadzum.Framework.Data.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leadzum.Framework.Data.Entities
{
    public partial class RolePermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolePermissionId { get; set; } // RolePermissionId (Primary key)
        [Required]
        public int PermissionId { get; set; } // PermissionId
        [Required]
        public bool AllowAccess { get; set; } // AllowAccess
        public int RoleId { get; set; } // RoleId
        public int? UserId { get; set; } // UserId
        public int? CreatedByUserId { get; set; } // CreatedByUserId
        public DateTime CreatedOnDate { get; set; } // CreatedOnDate
        public int? LastModifiedByUserId { get; set; } // LastModifiedByUserId
        public DateTime LastModifiedOnDate { get; set; } // LastModifiedOnDate

        // Foreign keys

        /// <summary>
        /// Parent Permission pointed by [RolePermission].([PermissionId]) (FK_dbo.RolePermission_dbo.Permission_PermissionId)
        /// </summary>
        public Permission Permission { get; set; } // FK_dbo.RolePermission_dbo.Permission_PermissionId

        public ApplicationUser User { get; set; }

        public IdentityRole Role { get; set; }
        public RolePermission()
        {
            CreatedOnDate = DateTime.Now;
            LastModifiedOnDate = DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
