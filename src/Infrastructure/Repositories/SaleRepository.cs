using Domain.Entities;
using Domain.Interfaces;
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
        
    }
}
