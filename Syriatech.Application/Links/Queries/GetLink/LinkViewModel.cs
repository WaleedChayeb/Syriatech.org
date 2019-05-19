using AutoMapper;
using Syriatech.Application.Interfaces.Mapping;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Links.Queries.GetLink
{
   public class LinkViewModel : IHaveCustomMapping
    {
        public int LinkId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Link, LinkViewModel>()
                .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>());
        }

        class PermissionsResolver : IValueResolver<Link, LinkViewModel, bool>
        { 
            public PermissionsResolver()
            {

            }

            public bool Resolve(Link source, LinkViewModel dest, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}
