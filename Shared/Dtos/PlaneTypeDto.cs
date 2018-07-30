using System;

namespace Shared.Dtos
{
    public class PlaneTypeDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int SeatsCapacity { get; set; }
        public int Carrying { get; set; }
        public TimeSpan LifeTime { get; set; }
    }
}
