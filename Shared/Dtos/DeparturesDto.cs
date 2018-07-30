using AirportWebApi.DAL.Models;
using System;

namespace Shared.Dtos
{
    public class DeparturesDto
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }

    }
}
