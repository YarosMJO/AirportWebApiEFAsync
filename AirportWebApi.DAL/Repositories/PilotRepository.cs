using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class PilotRepository : BaseRepository, IRepository<Pilot>
    {

        public PilotRepository(AirportContext context) : base(context)
        {
            if (!context.Pilots.Any())
                SetAll(seeder.Pilots);
            context.SaveChanges();
        }

        public void Add(Pilot entity)
        {
            context.Pilots.AddAsync(entity);
        }

        public async Task<IEnumerable<Pilot>> GetAll()
        {
            return await context.Pilots.ToListAsync();

        }
        public void SetAll(List<Pilot> entities)
        {
            entities.ForEach(x => context.Pilots.AddAsync(x));
        }

        public async Task<Pilot> GetById(int id)
        {
            return await context.Pilots.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await context.Pilots.FindAsync(id);
            if (item == null) return;
            context.Pilots.Remove(item);
        }

        public async Task Update(Pilot entity)
        {
            var item = await context.Pilots.FindAsync(entity.Id);
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }
    }
}