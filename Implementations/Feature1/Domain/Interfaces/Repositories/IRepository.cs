namespace Domain.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<T?> GetAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
}