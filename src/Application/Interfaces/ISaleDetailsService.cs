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
    public interface ISaleDetailsService
    {
        List<SaleDetailsDto> GetAll();
        SaleDetailsDto GetById(int id);
        void Create(SaleDetailsCreateRequest request);
        void Update(int id,SaleDetailsUpdateRequest request);
        void Delete(int id);
        
    }
}
