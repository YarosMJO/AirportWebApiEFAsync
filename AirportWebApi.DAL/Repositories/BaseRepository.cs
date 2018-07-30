using AirportWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Seeder;

namespace AirportWebApi.DAL.Repositories
{
    public class BaseRepository
    {

        public Seeder seeder = null;
        public AirportContext context;
        public BaseRepository() { }
        public BaseRepository(AirportContext context)
        {
            this.context = context;
            context.Database.Migrate();
            context.Database.EnsureCreated();
            seeder = new Seeder();
        }
    }

}
