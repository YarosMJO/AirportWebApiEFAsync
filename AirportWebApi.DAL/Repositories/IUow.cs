using AirportWebApi.DAL.Repositories;
using System.Threading.Tasks;

namespace AirportWebApi.DAL
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
