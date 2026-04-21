using StudentGuidance.Domain.Core;

namespace StudentGuidance.Infrastructure.Core;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
