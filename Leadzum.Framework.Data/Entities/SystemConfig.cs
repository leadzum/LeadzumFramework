using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace Leadzum.Framework.Data.Entities
{
    public partial class SystemConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigId { get; set; } // ConfigId (Primary key)
        [MaxLength(100)]
        [Required]
        public string ConfigCategory { get; set; } // ConfigCategory (length: 100)
        [MaxLength(100)]
        [Required]
        public string ConfigName { get; set; } // ConfigName (length: 100)
        [Required]
        public int DataType { get; set; } // DataType
        public int Length { get; set; } // Length
        [MaxLength(1000)]
        public string ValidationExpression { get; set; } // ValidationExpression (length: 2000)
        public string DefaultValue { get; set; } // DefaultValue
        public string ConfigValue { get; set; } // ConfigValue
        [Required]
        public int ViewOrder { get; set; } // ViewOrder
        [Required]
        public bool IsVisible { get; set; } // IsVisible
  
        public int? LastModifiedByUserId { get; set; } // LastModifiedByUserId
        [Required]
        public DateTime LastModifiedOnDate { get; set; } // LastModifiedOnDate

        public SystemConfig()
        {
            LastModifiedOnDate = DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }
}
