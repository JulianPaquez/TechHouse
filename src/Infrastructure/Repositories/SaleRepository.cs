using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SaleRepository : BaseRepository<Sale> , ISaleRepository
    {
        public SaleRepository(ApplicationContext context) : base(context) 
        {

        }

        public List<Sale> GetAll()
        {
            return _context.Set<Sale>().Include(s => s.SaleDetails).ToList();
        }

        public Sale? GetById<TId>(TId id)
        {
            return _context.Set<Sale>().Include(s => s.SaleDetails).FirstOrDefault(e => e.Id.Equals(id));
        }
        
    }
}
