using AirportWebApi.DAL.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace AirportWebApi.DAL.Models
{
    public class PlaneType : EntityBase
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public int SeatsCapacity { get; set; }
        [Required]
        public int Carrying { get; set; }
        [Required]
        public TimeSpan LifeTime { get; set; }
    }
}
