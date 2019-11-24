using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leadzum.Framework.Data.Entities
{
    public partial class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; } // ModuleId (Primary key)
        [MaxLength(100)]
        [Required]
        public string Code { get; set; } // Code (length: 100)
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } // Name (length: 100)
        [MaxLength(256)]
        public string Description { get; set; } // Description (length: 256)
        [Required]
        public int Type { get; set; }
        public int? ParentId { get; set; } // ParentId
        [MaxLength(100)]
        public string IconFile { get; set; } // IconFile (length: 100)
        [Required]
        public bool IsClickable { get; set; } // IsClickable
        [Required]
        public int ViewOrder { get; set; } // ViewOrder

        [MaxLength(32)]
        [Required]
        public string Area { get; set; } // Area (length: 32)

        [MaxLength(256)]
        [Required]
        public string Url { get; set; } // Url (length: 256)

        public int? CreatedByUserId { get; set; } // CreatedByUserId
        public DateTime CreatedOnDate { get; set; } // CreatedOnDate

        public int? LastModifiedByUserId { get; set; } // LastModifiedByUserId
        public DateTime LastModifiedOnDate { get; set; } // LastModifiedOnDate

        public ICollection<Module> Modules { get; set; } // Module.FK_dbo.Module_dbo.Module_ParentId

        public ICollection<Permission> Permissions { get; set; } // Permission.FK_dbo.Permission_dbo.Module_ModuleId

        // Foreign keys

        public Module Parent { get; set; } // FK_dbo.Module_dbo.Module_ParentId

        public Module()
        {
            CreatedOnDate = DateTime.Now;
            LastModifiedOnDate = DateTime.Now;
            Modules = new List<Module>();
            Permissions = new List<Permission>();
            InitializePartial();
        }

        partial void InitializePartial();
    }
}
