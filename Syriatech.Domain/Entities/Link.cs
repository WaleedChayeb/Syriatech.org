using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Domain.Entities
{
   public class Link
    {
        public int LinkId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; } 
        public string CreatedBy { get; set; }

    }
}
