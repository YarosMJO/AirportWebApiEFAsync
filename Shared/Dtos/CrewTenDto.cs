using AirportWebApi.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace Shared.Dtos
{
    public class CrewTenDto : EntityBase
    {
        public IEnumerable<CrewPilotDto> Pilot { get; set; }
        public IEnumerable<CrewStewardesDto> Stewardess { get; set; }

        public class CrewPilotDto
        {
            public int Id { get; set; }
            public int CrewId { get; set; }
            public DateTime BirthDate { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Exp { get; set; }
        }

        public class CrewStewardesDto
        {
            public int Id { get; set; }
            public int CrewId { get; set; }
            public DateTime BirthDate { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
