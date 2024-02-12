using Domain.Entities.Abstracts;

namespace DataAccess.Repositories.Abstracts;

public interface IBaseRepository<T> where T : BaseEntity, new()
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void Remove(int id);
    T? GetById(int id);
    ICollection<T>? GetAll();
    void SaveChanges();
}
