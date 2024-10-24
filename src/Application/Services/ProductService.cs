using System;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDto> GetAll()
        {
            var list = _productRepository.GetAll();
            return ProductDto.CreateList(list);
        }

        public ProductDto GetById(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            return ProductDto.Create(product);
        }

        public ProductDto GetByName(string name)
        {
            var product = _productRepository.GetByName(name);

            if (product == null)
            {
                throw new Exception($"Producto '{name}' no encontrado.");
            }
            return ProductDto.Create(product);
        }

        public void Create(ProductCreateRequest request)
        {
            var newProduct = new Product(request.Name, request.Stock, request.Price);
            _productRepository.Create(newProduct);
        }

        public void Update(int id, ProductUpdateRequest request)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;

            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }
            _productRepository.Delete(product);
        }

        public void ReduceStock(int productId, int quantity)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception("Producto no encontrado");
            }

            if (product.Stock < quantity)
            {
                throw new Exception("Stock insuficiente.");
            }

            product.Stock -= quantity;
            _productRepository.Update(product);
        }
    }
}
