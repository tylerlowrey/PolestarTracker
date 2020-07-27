using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PolestarTracker.Core.Models
{
    public class TrackingRecord
    {
        [Key]
        public int RecordId { get; set; }
        public string ProcessName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
