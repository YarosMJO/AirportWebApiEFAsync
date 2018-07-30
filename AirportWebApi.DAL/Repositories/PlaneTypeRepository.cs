using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class PlaneTypeRepository : BaseRepository, IRepository<PlaneType>
    {
        public PlaneTypeRepository(AirportContext context) : base(context)
        {
            if (!context.PlaneTypes.Any())
                SetAll(seeder.PlaneTypes);
            context.SaveChanges();
        }

        public void Add(PlaneType entity)
        {
            context.PlaneTypes.AddAsync(entity);
        }

        public async Task<IEnumerable<PlaneType>> GetAll()
        {
            return await context.PlaneTypes.ToListAsync();

        }
        public void SetAll(List<PlaneType> entities)
        {
            entities.ForEach(x => context.PlaneTypes.AddAsync(x));
        }

        public async Task<PlaneType> GetById(int id)
        {
            return await context.PlaneTypes.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await context.PlaneTypes.FindAsync(id);
            if (item == null) return;
            context.PlaneTypes.Remove(item);
        }

        public async Task Update(PlaneType entity)
        {
            var item = await context.PlaneTypes.FindAsync(entity.Id);
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }

    }
}
