using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class DepartureRepository : BaseRepository, IRepository<Departure>
    {
        public DepartureRepository(AirportContext context) : base(context)
        {
            if (!context.Departures.Any())
                SetAll(seeder.departures);
            context.SaveChanges();
        }

        public void Add(Departure entity)
        {
            context.Departures.AddAsync(entity);
        }

        public async Task<IEnumerable<Departure>> GetAll()
        {
            return await context.Departures.Include(item => item.Crew).Include(item => item.Plane).ToListAsync();

        }
        public void SetAll(List<Departure> entities)
        {
            entities.ForEach(x => context.Departures.AddAsync(x));
        }

        public async Task<Departure> GetById(int id)
        {
            return await context.Departures.Include(user => user.Crew).Include(user => user.Plane).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Remove(int id)
        {
            var item = await context.Departures.Include(user => user.Crew).Include(user => user.Plane).FirstOrDefaultAsync(c => c.Id == id);
            if (item == null) return;
            context.Departures.Remove(item);
        }

        public async Task Update(Departure entity)
        {
            var item = await context.Departures.FindAsync(entity.Id);
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }

    }
}
