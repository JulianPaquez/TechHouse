using Doain.Interfaces;
using Domain.Interfaces;


namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : class,IEntity,IBaseRepository<T>
    {
        private List<T> Entities { get; set; } = new List<T>();

        public List<T> GetAll()
        {
            return Entities;
        }

        public T GetById(int id) 
        {
            return Entities.Find(e => e.Id == id);
        }

        public void Delete(T entity) 
        {
            Entities.Remove(entity);
        }

        public void Update(T entity) 
        { 
            var index = Entities.FindIndex(e => e.Id == entity.Id); // el FindIndex lo que hace es encontrar el primer elemento que tenga el mismno id que la entidad que se esta pasando como argumento
            if (index != -1) 
            {
                Entities[index] = entity; // si se encuentra el id se cambia el elemento que esta en esa posici�n por la nueva entidad que nosotros paamos como parametro
            }
        }

        public int Create(T entity) 
        {
           Entities.Add(entity);
            return entity.Id;
        } //por ahora queda as�


    }
}