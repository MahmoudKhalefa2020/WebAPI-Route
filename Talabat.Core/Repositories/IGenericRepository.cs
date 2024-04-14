using Talabat.Core.Entities;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetbyidAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
