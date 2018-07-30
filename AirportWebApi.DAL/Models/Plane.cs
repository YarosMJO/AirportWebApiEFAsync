using AirportWebApi.DAL.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace AirportWebApi.DAL.Models
{
    public class Plane : EntityBase
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }
        [Required]
        public PlaneType Type { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public TimeSpan LifeTime { get; set; }
    }
}
