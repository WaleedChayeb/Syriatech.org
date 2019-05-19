using AutoMapper;
using Syriatech.Application.Interfaces.Mapping;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Projects.Queries.GetAllProjects
{
    public class ProjectDto : IHaveCustomMapping
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Project, ProjectDto>();
        }
    }
}
