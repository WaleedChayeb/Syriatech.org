﻿using AutoMapper;
using Syriatech.Application.Interfaces.Mapping;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Events.Queries.GetAllEvents
{
    public class EventDto : IHaveCustomMapping
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Event, EventDto>();
        }
    }
}
