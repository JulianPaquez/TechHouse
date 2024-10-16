namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById<TId>(TId id);
        void Delete(T entity);
        T Update(T entity);
        T Create(T entity);
        
        
    }
}