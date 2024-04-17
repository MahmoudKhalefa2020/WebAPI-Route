﻿using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetbyidAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
        Task<T?> GetWithSpecAsync(ISpecifications<T> spec);

    }
}
