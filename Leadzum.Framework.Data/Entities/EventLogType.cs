using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leadzum.Framework.Data.Entities
{
    public partial class EventLogType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogTypeId { get; set; } // LogTypeId (Primary key)
        public int LogCategory { get; set; } // LogCategory

        [MaxLength(50)]
        [Required]
        public string Key { get; set; } // LogTypeKey (length: 50)
        [MaxLength(50)]
        [Required]
        public string FriendlyName { get; set; } // FriendlyName (length: 50)
        [MaxLength(256)]
        public string Description { get; set; } // Description (length: 256)
        public bool LoggingIsActive { get; set; } // LoggingIsActive
        public int? KeepMostRecent { get; set; } // KeepMostRecent
        public bool? EmailNotificationIsActive { get; set; } // EmailNotificationIsActive
        [MaxLength(50)]
        public string MailToAddress { get; set; } // MailToAddress (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child EventLogs where [EventLog].[LogTypeId] point to this entity (FK_dbo.EventLog_dbo.EventLogType_LogTypeId)
        /// </summary>
        public ICollection<EventLog> EventLogs { get; set; } // EventLog.FK_dbo.EventLog_dbo.EventLogType_LogTypeId

        public EventLogType()
        {
            EventLogs = new List<EventLog>();
            InitializePartial();
        }

        partial void InitializePartial();
    }
}
