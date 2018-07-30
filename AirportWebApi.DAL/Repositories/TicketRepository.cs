using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public class TicketRepository : BaseRepository, IRepository<Ticket>
    {
        public TicketRepository(AirportContext context) : base(context)
        {
            if (!context.Tickets.Any())
                SetAll(seeder.Tickets);
            context.SaveChanges();
        }

        public void Add(Ticket entity)
        {
            context.Tickets.AddAsync(entity);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await context.Tickets.ToListAsync();

        }
        public void SetAll(List<Ticket> entities)
        {
            entities.ForEach(x => context.Tickets.AddAsync(x));
        }

        public async Task<Ticket> GetById(int id)
        {
            return await context.Tickets.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await context.Tickets.FindAsync(id);
            if (item == null) return;
            context.Tickets.Remove(item);
        }

        public async Task Update(Ticket entity)
        {
            var item = await context.Tickets.FindAsync(entity.Id);
            if (item == null) return;
            context.Entry(item).CurrentValues.SetValues(entity);
        }


    }
}