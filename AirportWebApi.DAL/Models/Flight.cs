using AirportWebApi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirportWebApi.DAL.Models
{
    public class Flight : EntityBase
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DepartureTime { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Departure point must be at least 5 characters long")]
        public string DeparturePoint { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Destination must be at least 5 characters long")]
        public string Destination { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public List<Ticket> Tickets { get; set; }

    }
}
