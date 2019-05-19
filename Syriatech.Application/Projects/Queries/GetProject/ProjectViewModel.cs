using AutoMapper;
using Syriatech.Application.Interfaces.Mapping;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Projects.Queries.GetProject
{
   public class ProjectViewModel : IHaveCustomMapping
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Project, ProjectViewModel>()
                .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>());
        }

        class PermissionsResolver : IValueResolver<Project, ProjectViewModel, bool>
        { 
            public PermissionsResolver()
            {

            }

            public bool Resolve(Project source, ProjectViewModel dest, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}
