using Domain.Interfaces;
using Domain.Interfaces;


namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class , IEntity
    {
       private static List<T> Entities { get; set; } = new List<T>();

        public List<T> GetAll()
        {
            return Entities;
        }

        public T GetById(int id) 
        {
        
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(T entity) 
        {
            Entities.Remove(entity);
        }

        public void Update(int id,T entity) 
        { 
            var index = Entities.FindIndex(e => e.Id == entity.Id); // el FindIndex lo que hace es encontrar el primer elemento que tenga el mismno id que la entidad que se esta pasando como argumento
            if (index != -1) 
            {
                Entities[index] = entity; // si se encuentra el id se cambia el elemento que esta en esa posicion por la nueva entidad que nosotros paamos como parametro
            }
        }

        public int Create(T entity) 
        {
            entity.Id = Entities.Count() +1;
           Entities.Add(entity);
            return entity.Id;
        } //por ahora queda asi

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}