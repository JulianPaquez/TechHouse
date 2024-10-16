using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleServices
    {
        List<SaleDto> GetAll();
        SaleDto GetById(int id);
        Sale Create(SaleCreateRequest request);
        void Update(int id,SaleUpdateRequest request);
        void Delete(int id);

    }
}
