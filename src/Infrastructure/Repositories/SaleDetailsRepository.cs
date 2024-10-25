using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SaleDetailsRepository : BaseRepository<SaleDetails>, ISaleDetailsRepository
    {
        public SaleDetailsRepository(ApplicationContext context) : base(context) 
        { 

        }

    }
}
