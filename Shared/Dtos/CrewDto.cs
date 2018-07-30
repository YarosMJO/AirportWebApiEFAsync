using AirportWebApi.DAL.Models;
using System.Collections.Generic;

namespace Shared.Dtos
{
    public class CrewDto
    {
        public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public List<FlightAttendant> FlightAttendants { get; set; }
    }
}
