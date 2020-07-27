using System;
using System.Collections.Generic;
using System.Text;

namespace PolestarTracker.Core.Models
{
    class TrackingRecord
    {
        public int RecordId { get; set; }
        public string ProcessName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
