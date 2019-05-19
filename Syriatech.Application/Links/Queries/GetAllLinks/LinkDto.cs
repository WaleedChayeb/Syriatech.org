using AutoMapper;
using Syriatech.Application.Interfaces.Mapping;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Links.Queries.GetAllLinks
{
    public class LinkDto : IHaveCustomMapping
    { 

        public int LinkId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Link, LinkDto>();
        }
    }
}
