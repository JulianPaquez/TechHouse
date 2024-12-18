﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        List<Sale> GetAll();
        Sale? GetById<TId>(TId id);

    }

}
