using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        } 

        public List<T> GetAll()
        {
            
             return _context.Set<T>().ToList(); //que es set?
        }

        public T? GetById<TId>(TId id) 
        {
        
            return _context.Set<T>().Find(new object[] {id});
        }

        public void Delete(T entity) 
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            

        }

        public T Update(T entity) 
        { 
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
            /*var index = Entities.FindIndex(e => e.Id == entity.Id); // el FindIndex lo que hace es encontrar el primer elemento que tenga el mismno id que la entidad que se esta pasando como argumento
            if (index != -1) 
            {
                Entities[index] = entity; // si se encuentra el id se cambia el elemento que esta en esa posicion por la nueva entidad que nosotros paamos como parametro
            }*/
        }

        public T Create(T entity) 
        {

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
            /*entity.Id = Entities.Count() +1;
           Entities.Add(entity);
            return entity.Id;*/

            // _context.Set<T>().Add(entity)
            // _context.SaveChanges(); //aca se le da el id al entity
            //return entity

        } //por ahora queda asi

        
    }
}