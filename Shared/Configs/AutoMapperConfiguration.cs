using AirportWebApi.DAL.Models;
using AutoMapper;
using Shared.Dtos;

namespace Shared.Configs
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDto>();

                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<Departure, DeparturesDto>();

                cfg.CreateMap<Crew, CrewDto>();
                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<FlightAttendant, FlightAttendantDto>();

                cfg.CreateMap<Plane, PlaneDto>();
                cfg.CreateMap<PlaneType, PlaneTypeDto>();

                cfg.CreateMap<Crew, CrewTenDto>();

                cfg.CreateMap<CrewTenDto.CrewStewardesDto, FlightAttendant>()
                 .ForMember(x => x.Id, y => y.Ignore())
                 .ForMember(x => x.Name, y => y.MapFrom(z => z.FirstName))
                 .ForMember(x => x.Surname, y => y.MapFrom(z => z.LastName))
                 .ForMember(x => x.Birthday, y => y.MapFrom(z => z.BirthDate));

                cfg.CreateMap<CrewTenDto.CrewPilotDto, Pilot>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Name, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Birthday, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Experience, y => y.Ignore());

            });
            return config;
        }
    }
}
