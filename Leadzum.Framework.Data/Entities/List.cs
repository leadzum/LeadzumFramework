using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leadzum.Framework.Data.Entities
{
    public partial class List
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntryId { get; set; } // EntryId (Primary key)
        [MaxLength(50)]
        [Required]
        [ConcurrencyCheck]
        public string ListName { get; set; } // ListName (length: 50)
        [MaxLength(100)]
        [Required]
        [ConcurrencyCheck]
        public string Value { get; set; } // Value (length: 100)
        [MaxLength(256)]
        [Required]
        public string Text { get; set; } // Text (length: 256)
        public int? ParentId { get; set; } // ParentId
        [Required]
        public int SortOrder { get; set; } // SortOrder
        public int? CreatedByUserId { get; set; } // CreatedByUserId
        public DateTime CreatedOnDate { get; set; } // CreatedOnDate
        public int? LastModifiedByUserId { get; set; } // LastModifiedByUserId
        public DateTime LastModifiedOnDate { get; set; } // LastModifiedOnDate

         public ICollection<List> Lists { get; set; } // List.FK_dbo.List_dbo.List_ParentId

        // Foreign keys

        /// <summary>
        /// Parent List pointed by [List].([ParentId]) (FK_dbo.List_dbo.List_ParentId)
        /// </summary>
        public List Parent { get; set; } // FK_dbo.List_dbo.List_ParentId

        public List()
        {
            CreatedOnDate = DateTime.Now;
            LastModifiedOnDate = DateTime.Now;
            Lists = new List<List>();
            InitializePartial();
        }

        partial void InitializePartial();
    }
}
