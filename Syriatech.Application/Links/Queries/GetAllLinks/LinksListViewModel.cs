using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Links.Queries.GetAllLinks
{
    public class LinksListViewModel
    {
        public IEnumerable<LinkDto> Links { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
