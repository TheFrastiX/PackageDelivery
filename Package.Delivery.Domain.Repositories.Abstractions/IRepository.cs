using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryParcel.Domain.Repositories.Abstractions
{
    /// <summary>
    /// Базовый интерфейс репозитория с CRUD операциями.
    /// </summary>
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> ExistsAsync(TId id);
    }
}
