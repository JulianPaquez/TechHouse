using System;
using Application.Models;
using Application.Models.Request;

namespace Application.Interfaces;

public interface IProductService
{
    List<ProductDto> GetAll();
    ProductDto GetById(int id);
    void Create(ProductCreateRequest request);
    void Update(int id,ProductUpdateRequest request);
    void Delete(int id);
    void ReduceStock(int ProductId, int Stock);
    ProductDto GetByName(string name);
}
