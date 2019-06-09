using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Leadzum.Framework.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Leadzum.Framework.Data.IdentityEntities
{
    public class IdentityRole : IdentityRole<int>
    {
        [MaxLength(50)]
        [Required]
        public string RoleCode { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public int? UserCategory { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }
      
        public int? LastModifiedByUserId { get; set; }

        public DateTime LastModifiedOnDate { get; set; }

        [ForeignKey("RoleId")]
        public ICollection<RolePermission> RolePermissions { get; set; }

        public IdentityRole()
        {
            CreatedOnDate = DateTime.Now;
            LastModifiedOnDate = DateTime.Now;
        }

        public IdentityRole(string name)
        {
            Name = name;
            CreatedOnDate = DateTime.Now;
            LastModifiedOnDate = DateTime.Now;
        }
    }
}
