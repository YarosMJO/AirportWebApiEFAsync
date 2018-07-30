using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AirportWebApi.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetAll();

        void Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(int id);

        //Task<TEntity> GetItemByPredicate(Func<TEntity, bool> predicate);

        void SetAll(List<TEntity> entity);

    }
    public abstract class EntityBase
    {
        [Required]
        public int Id { get; set; }
    }
}