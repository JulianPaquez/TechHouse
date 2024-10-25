using System;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Product GetByName(string name);
}
