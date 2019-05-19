using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Domain.Entities
{
    public class Project
    {  
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }

    }
}
