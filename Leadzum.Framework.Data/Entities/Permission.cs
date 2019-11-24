using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leadzum.Framework.Data.Entities
{
    public partial class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; } // PermissionId (Primary key)
        [Required]
        public int ModuleId { get; set; } // ModuleId
        [MaxLength(50)]
        public string PermissionCode { get; set; } // PermissionCode (length: 50)
        [MaxLength(50)]
        [Required]
        public string PermissionKey { get; set; } // PermissionKey (length: 50)
        [MaxLength(50)]
        [Required]
        public string PermissionName { get; set; } // PermissionName (length: 50)
        public bool IsConfigurable { get; set; } // IsConfigurable
        [Required]
        public int Priority { get; set; } // Priority

        // Reverse navigation

        /// <summary>
        /// Child RolePermissions where [RolePermission].[PermissionId] point to this entity (FK_dbo.RolePermission_dbo.Permission_PermissionId)
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; } // RolePermission.FK_dbo.RolePermission_dbo.Permission_PermissionId

        // Foreign keys

        /// <summary>
        /// Parent Module pointed by [Permission].([ModuleId]) (FK_dbo.Permission_dbo.Module_ModuleId)
        /// </summary>
        public Module Module { get; set; } // FK_dbo.Permission_dbo.Module_ModuleId

        public Permission()
        {
            RolePermissions = new List<RolePermission>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
