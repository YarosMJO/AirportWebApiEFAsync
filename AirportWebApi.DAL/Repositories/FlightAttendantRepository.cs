using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class FlightAttendantRepository : BaseRepository, IRepository<FlightAttendant>
    {
        public FlightAttendantRepository(AirportContext context) : base(context)
        {
            if (!context.FlightAttendants.Any())
                SetAll(seeder.FlightAttendants);
            context.SaveChanges();
        }

        public void Add(FlightAttendant entity)
        {
            context.FlightAttendants.AddAsync(entity);
        }

        public async Task<IEnumerable<FlightAttendant>> GetAll()
        {
            return await context.FlightAttendants.ToListAsync();

        }
        public void SetAll(List<FlightAttendant> entities)
        {
            entities.ForEach(x => context.FlightAttendants.AddAsync(x));
        }

        public async Task<FlightAttendant> GetById(int id)
        {
            return await context.FlightAttendants.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await context.FlightAttendants.FindAsync(id);
            if (item == null) return;
            context.FlightAttendants.Remove(item);
        }

        public async Task Update(FlightAttendant entity)
        {
            var item = await context.FlightAttendants.FindAsync(entity.Id);
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }
    }
}
