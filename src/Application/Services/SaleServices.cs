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
            var productNames = new List<string>();
            int totalProductQuantity = 0; // Variable para almacenar la cantidad total de productos

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
                    Stock = productSaleRequest.Stock,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    TotalAmount = product.Price * productSaleRequest.Stock // Calcular el monto total para este detalle
                };

                saleDetailsList.Add(saleDetail);
                productNames.Add(product.Name);
                totalProductQuantity += productSaleRequest.Stock; // Sumar la cantidad vendida de este producto
            }

            // Calcular el total de la venta
            var totalAmount = CalculateTotalSaleAmount(saleDetailsList);

            // Concatenar los nombres de los productos en una cadena separada por comas
            var productNamesString = string.Join(", ", productNames);

            // Crear la venta incluyendo los nombres de los productos y la cantidad total
            var sale = new Sale(request.DateTime, totalAmount, productNamesString, totalProductQuantity);

            // Agregar los detalles de venta a la venta
            foreach (var detail in saleDetailsList)
            {
                sale.SaleDetails.Add(detail);
            }

            _saleRepository.Create(sale);
        }



        public void Update(int id, SaleUpdateRequest request)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null)
            {
                throw new Exception("Venta no encontrada");
            }

            // Revertir el stock de los productos en la venta original
            foreach (var detail in sale.SaleDetails)
            {
                var originalProduct = _productService.GetById(detail.ProductId);
                _productService.IncreaseStock(originalProduct.Id, detail.Stock);
            }

            
            sale.SaleDetails.Clear();

            
            var saleDetailsList = new List<SaleDetails>();
            var productNames = new List<string>();

            
            var product = _productService.GetByName(request.ProductSale);
            if (product == null)
            {
                throw new Exception($"Producto '{request.ProductSale}' no encontrado.");
            }

            
            if (product.QuantityStock < request.ProductQuantity)
            {
                throw new Exception($"Stock insuficiente para el producto '{product.Name}'. Stock disponible: {product.QuantityStock}");
            }
            _productService.ReduceStock(product.Id, request.ProductQuantity);

            
            var saleDetail = new SaleDetails
            {
                ProductId = product.Id,
                Stock = request.ProductQuantity,
                ProductName = product.Name,
                ProductPrice = product.Price,
                TotalAmount = product.Price * request.ProductQuantity
            };

            saleDetailsList.Add(saleDetail);
            productNames.Add(product.Name);

            
            var totalAmount = CalculateTotalSaleAmount(saleDetailsList);
            var productNamesString = string.Join(", ", productNames);

           
            sale.DateTime = request.DateTime;
            sale.TotalSaleAmount = totalAmount;
            sale.ProductSale = productNamesString;

            
            foreach (var detail in saleDetailsList)
            {
                sale.SaleDetails.Add(detail);
            }

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
