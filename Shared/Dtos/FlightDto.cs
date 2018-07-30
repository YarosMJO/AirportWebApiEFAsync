using AirportWebApi.DAL.Models;
using System;
using System.Collections.Generic;

namespace Shared.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DeparturePoint { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
