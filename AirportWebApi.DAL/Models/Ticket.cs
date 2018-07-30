using AirportWebApi.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace AirportWebApi.DAL.Models
{
    public class Ticket : EntityBase
    {
        [Required]
        public int Price { get; set; }
        [Required]
        public int FlightNumber { get; set; }
    }
}