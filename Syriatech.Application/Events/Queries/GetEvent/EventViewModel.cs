using AutoMapper;
using Syriatech.Application.Interfaces.Mapping;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Events.Queries.GetEvent
{
   public class EventViewModel : IHaveCustomMapping
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>());
        }

        class PermissionsResolver : IValueResolver<Event, EventViewModel, bool>
        { 
            public PermissionsResolver()
            {

            }

            public bool Resolve(Event source, EventViewModel dest, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}
