using AirportWebApi.DAL.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace AirportWebApi.DAL.Models
{
    public class FlightAttendant : EntityBase
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Surname must be at least 3 characters long")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

    }
}
