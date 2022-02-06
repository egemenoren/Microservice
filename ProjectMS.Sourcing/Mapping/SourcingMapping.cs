using AutoMapper;
using EventBusRabbitMQ.Events;
using ProjectMS.Sourcing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMS.Sourcing.Mapping
{
    public class SourcingMapping : Profile
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvents, Bids>().ReverseMap();
        }
    }
}
