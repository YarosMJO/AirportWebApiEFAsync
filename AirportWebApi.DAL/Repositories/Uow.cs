using AirportWebApi.DAL.Models;
using AirportWebApi.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace AirportWebApi.DAL
{
    public class Uow : IUow
    {
        private AirportContext context;

        public Uow(AirportContext context)
        {
            this.context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            switch (typeof(T).Name)
            {
                case "Ticket": return (IRepository<T>)TicketRepository;
                case "Flight": return (IRepository<T>)FlightRepository;
                case "Departure": return (IRepository<T>)DepartureRepository;
                case "Crew": return (IRepository<T>)CrewRepository;
                case "Pilot": return (IRepository<T>)PilotRepository;
                case "FlightAttendant": return (IRepository<T>)FlightAttendantRepository;
                case "Plane": return (IRepository<T>)PlaneRepository;
                case "PlaneType": return (IRepository<T>)PlaneTypeRepository;
                default: throw new Exception();
            };

        }

        private TicketRepository ticketRepository;
        public IRepository<Ticket> TicketRepository
        {
            get
            {
                if (ticketRepository == null)
                {
                    ticketRepository = new TicketRepository(context);
                }
                return ticketRepository;
            }
        }

        private FlightRepository flightRepository;
        public IRepository<Flight> FlightRepository
        {
            get
            {
                if (flightRepository == null)
                {
                    flightRepository = new FlightRepository(context);
                }
                return flightRepository;
            }
        }

        private DepartureRepository departureRepository;
        public IRepository<Departure> DepartureRepository
        {
            get
            {
                if (departureRepository == null)
                {
                    departureRepository = new DepartureRepository(context);
                }
                return departureRepository;
            }
        }
        private CrewRepository crewRepository;
        public IRepository<Crew> CrewRepository
        {
            get
            {
                if (crewRepository == null)
                {
                    crewRepository = new CrewRepository(context);
                }
                return crewRepository;
            }
        }

        private PilotRepository pilotRepository;
        public IRepository<Pilot> PilotRepository
        {
            get
            {
                if (pilotRepository == null)
                {
                    pilotRepository = new PilotRepository(context);
                }
                return pilotRepository;
            }
        }

        private FlightAttendantRepository flightAttendantRepository;
        public IRepository<FlightAttendant> FlightAttendantRepository
        {
            get
            {
                if (flightAttendantRepository == null)
                {
                    flightAttendantRepository = new FlightAttendantRepository(context);
                }
                return flightAttendantRepository;
            }
        }

        private PlaneRepository planeRepository;
        public IRepository<Plane> PlaneRepository
        {
            get
            {
                if (planeRepository == null)
                {
                    planeRepository = new PlaneRepository(context);
                }
                return planeRepository;
            }
        }

        private PlaneTypeRepository planeTypeRepository;

        public IRepository<PlaneType> PlaneTypeRepository
        {
            get
            {
                if (planeTypeRepository == null)
                {
                    planeTypeRepository = new PlaneTypeRepository(context);
                }
                return planeTypeRepository;
            }
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
