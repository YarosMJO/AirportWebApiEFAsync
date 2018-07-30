using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class PlaneRepository : BaseRepository, IRepository<Plane>
    {
        public PlaneRepository(AirportContext context) : base(context)
        {
            if (!context.Planes.Any())
            {
                List<Plane> ss = seeder.Planes;
                SetAll(seeder.Planes);
            }
            context.SaveChanges();
        }

        public void Add(Plane entity)
        {
            context.Planes.AddAsync(entity);
        }

        public async Task<IEnumerable<Plane>> GetAll()
        {
            return await context.Planes.Include(user => user.Type).ToListAsync();

        }
        public void SetAll(List<Plane> entities)
        {
            entities.ForEach(x => context.Planes.AddAsync(x));
        }

        public async Task<Plane> GetById(int id)
        {
            return await context.Planes.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await context.Planes.Include(user => user.Type).FirstOrDefaultAsync(c => c.Id == id);
            if (item == null) return;
            context.Planes.Remove(item);
        }

        public async Task Update(Plane entity)
        {
            var item = await context.Planes.FindAsync(entity.Id);
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }
    }
}
