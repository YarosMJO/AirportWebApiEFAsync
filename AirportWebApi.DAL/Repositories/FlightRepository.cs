using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class FlightRepository : BaseRepository, IRepository<Flight>
    {
        public FlightRepository(AirportContext context) : base(context)
        {
            if (!context.Flights.Any())
                SetAll(seeder.Flights);
            context.SaveChanges();
        }

        public void Add(Flight entity)
        {
            context.Flights.AddAsync(entity);
        }

        public async Task<IEnumerable<Flight>> GetAll()
        {
            return await context.Flights.Include(user => user.Tickets).ToListAsync();

        }
        public void SetAll(List<Flight> entities)
        {
            entities.ForEach(x => context.Flights.AddAsync(x));
        }

        public async Task<Flight> GetById(int id)
        {
            return await context.Flights.Include(user => user.Tickets).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Remove(int id)
        {
            var item = await context.Flights.Include(user => user.Tickets).FirstOrDefaultAsync(c => c.Id == id);
            if (item == null) return;
            context.Flights.Remove(item);
        }

        public async Task Update(Flight entity)
        {
            var item = await context.Flights.FindAsync(entity.Id);
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }

    }
}