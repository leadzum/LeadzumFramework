using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leadzum.Framework.Data.Entities
{
    public partial class EventLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EventLogId { get; set; } // EventLogId (Primary key)
        public int LogTypeId { get; set; } // LogTypeId
        public int? LogUserId { get; set; } // LogUserId
        [MaxLength(256)]
        public string LogUserName { get; set; } // LogUserName (length: 256)
        public System.DateTime LogCreatedDate { get; set; } // LogCreatedDate
        [MaxLength(256)]
        [Required]
        public string LogMachineName { get; set; } // LogMachineName (length: 256)
        [Required]
        public string LogDetail { get; set; } // LogDetail
        public bool? LogNotificationPending { get; set; } // LogNotificationPending

        // Foreign keys

        /// <summary>
        /// Parent EventLogType pointed by [EventLog].([LogTypeId]) (FK_dbo.EventLog_dbo.EventLogType_LogTypeId)
        /// </summary>
        public EventLogType EventLogType { get; set; } // FK_dbo.EventLog_dbo.EventLogType_LogTypeId

        public EventLog()
        {
            LogCreatedDate = System.DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }
}
