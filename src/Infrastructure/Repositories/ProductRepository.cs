using System;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationContext context) : base(context)
    {
    }

    public Product GetByName(string name)
    {
        return _context.Set<Product>().FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
    }    
}
