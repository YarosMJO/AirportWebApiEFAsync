using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class CrewRepository : BaseRepository, IRepository<Crew>
    {
        public CrewRepository(AirportContext context) : base(context)
        {
            if (!context.Crews.Any())
            {
                List<Crew> s = seeder.Crews;
                SetAll(seeder.Crews);
            }
            context.SaveChanges();
        }

        public void Add(Crew entity)
        {
            context.Crews.AddAsync(entity);
        }

        public async Task<IEnumerable<Crew>> GetAll()
        {
            return await context.Crews.Include(user => user.FlightAttendants).Include(user => user.Pilot).ToListAsync();

        }
        public void SetAll(List<Crew> entities)
        {
            entities.ForEach(x => context.Crews.AddAsync(x));
        }

        public async Task<Crew> GetById(int id)
        {
            return await context.Crews.Include(user => user.FlightAttendants).Include(user => user.Pilot).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Remove(int id)
        {
            var item = await context.Crews.Include(user => user.FlightAttendants).Include(user => user.Pilot).FirstOrDefaultAsync(c => c.Id == id);
            if (item == null) return;
            context.Crews.Remove(item);
        }

        public async Task Update(Crew entity)
        {
            var item = await context.Crews.Where(x => x.Id == entity.Id).FirstAsync();
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }
    }
}
