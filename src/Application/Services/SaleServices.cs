using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class SaleServices : ISaleServices
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleDetailsRepository _saleDetailsRepository;
        private readonly IProductService _productService;

        public SaleServices(ISaleRepository saleRepository, ISaleDetailsRepository saleDetailsRepository, IProductService productService)
        {
            _saleRepository = saleRepository;
            _saleDetailsRepository = saleDetailsRepository;
            _productService = productService;
        }

        public List<SaleDto> GetAll()
        {
            var list = _saleRepository.GetAll();
            return SaleDto.CreateList(list);
        }

        public SaleDto GetById(int id)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null)
            {
                throw new Exception("Venta no encontrada");
            }
            return SaleDto.Create(sale);
        }

        public void Create(SaleCreateRequest request)
        {
            var saleDetailsList = new List<SaleDetails>();

            foreach (var productSaleRequest in request.ProductSales)
            {
                // Buscar el producto por nombre
                var product = _productService.GetByName(productSaleRequest.Name);

                if (product == null)
                {
                    throw new Exception($"Producto '{productSaleRequest.Name}' no encontrado.");
                }

                // Validar si el producto tiene suficiente stock
                if (product.QuantityStock < productSaleRequest.Stock)
                {
                    throw new Exception($"Stock insuficiente para el producto '{product.Name}'. Stock disponible: {product.QuantityStock}");
                }

                // Restar stock del producto
                _productService.ReduceStock(product.Id, productSaleRequest.Stock);

                // Crear los detalles de la venta
                var saleDetail = new SaleDetails
                {
                    ProductId = product.Id,
                    Stock = productSaleRequest.Stock
                };

                saleDetailsList.Add(saleDetail);
            }

            // Calcular el total de la venta
            var totalAmount = CalculateTotalSaleAmount(saleDetailsList);

            // Crear la venta
            var sale = new Sale(request.DateTime, totalAmount);
            _saleRepository.Create(sale);
        }

        public void Update(int id, SaleUpdateRequest request)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null)
            {
                throw new Exception("Venta no encontrada");
            }

            sale.DateTime = request.DateTime;
            sale.TotalSaleAmount = request.TotalSaleAmount;

            _saleRepository.Update(sale);
        }

        public void Delete(int id)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null)
            {
                throw new Exception("Venta no encontrada");
            }
            _saleRepository.Delete(sale);
        }

        private decimal CalculateTotalSaleAmount(List<SaleDetails> saleDetailsList)
        {
            decimal total = 0;
            foreach (var detail in saleDetailsList)
            {
                var product = _productService.GetById(detail.ProductId);
                total += product.Price * detail.Stock;
            }
            return total;
        }
    }
}
