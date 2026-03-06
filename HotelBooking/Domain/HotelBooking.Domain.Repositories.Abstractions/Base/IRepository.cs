using HotelBooking.Domain.Base;

namespace HotelBooking.Domain.Repositories.Abstractions.Base;

public interface IRepository<TEntity, in TId>
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <param name="asNoTracking">If true, entities are not tracked by EF Core.</param>
    /// <returns>Collection of entities.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);

    /// <summary>
    /// Gets entity by ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Entity if found, otherwise null.</returns>
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// Adds new entity.
    /// </summary>
    /// <param name="entity">Entity to add.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Added entity.</returns>
    Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Updates existing entity.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if updated, false otherwise.</returns>
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes entity.
    /// </summary>
    /// <param name="entity">Entity to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if deleted, false otherwise.</returns>
    Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes entity by ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if deleted, false otherwise.</returns>
    Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken);
}
