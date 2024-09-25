namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Delete(T entity);
        void Update(T entity);
        int Create(T entity);
    }
}