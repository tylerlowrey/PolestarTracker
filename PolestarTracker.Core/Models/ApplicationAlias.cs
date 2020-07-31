using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PolestarTracker.Core.Models
{
    public class ApplicationAlias
    {
        [Key]
        public int Id { get; set; }
        public string Alias { get; set; }
        public string ProcessName { get; set; }
    }
}
