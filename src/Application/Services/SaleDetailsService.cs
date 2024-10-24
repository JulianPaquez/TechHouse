using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SaleDetailsService : ISaleDetailsService
    {
        private readonly ISaleDetailsRepository _saleDetailsRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public SaleDetailsService(ISaleDetailsRepository saleDetailsRepository, ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _saleDetailsRepository = saleDetailsRepository;
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

        public List<SaleDetailsDto> GetAll()
        {
            var saleDetailsList = _saleDetailsRepository.GetAll();

            if (saleDetailsList == null || !saleDetailsList.Any())
            {
                throw new Exception("No se encontraron detalles de ventas.");
            }

            return SaleDetailsDto.CreateList(saleDetailsList);
        }

        public SaleDetailsDto GetById(int id)
        {
            var details = _saleDetailsRepository.GetById(id);
            if (details == null)
            {
                throw new Exception("Detalle de la venta no encontrado");
            }

            return SaleDetailsDto.Create(details);
        }

        public void Create(SaleDetailsCreateRequest request)
        {
            var productFound = _productRepository.GetById(request.ProductId);
            var saleFound = _saleRepository.GetById(request.SaleId);

            if (productFound == null || saleFound == null)
            {
                throw new Exception("Producto o venta no encontrado");
            }

            var saleDetails = new SaleDetails
            {
                Sale = saleFound,
                Product = productFound,
                ProductId = productFound.Id,
                SaleId = saleFound.Id,
                ProductName = productFound.Name,
                ProductPrice = productFound.Price,
                Stock = request.Stock,
                TotalAmount = productFound.Price * request.Stock
            };

            _saleDetailsRepository.Create(saleDetails);
        }

        public void Update(int id, SaleDetailsUpdateRequest request)
        {
            var saleDetails = _saleDetailsRepository.GetById(id);
            if (saleDetails == null)
            {
                throw new Exception("No se encontró un registro de una venta");
            }

            var productFound = _productRepository.GetById(request.ProductId);
            var saleFound = _saleRepository.GetById(request.SaleId);

            if (productFound == null || saleFound == null)
            {
                throw new Exception("Producto o venta no encontrado");
            }

            saleDetails.ProductId = request.ProductId;
            saleDetails.SaleId = request.SaleId;
            saleDetails.ProductName = productFound.Name;
            saleDetails.ProductPrice = productFound.Price;
            saleDetails.Stock = request.Stock;
            saleDetails.TotalAmount = productFound.Price * request.Stock;

            _saleDetailsRepository.Update(saleDetails);
        }

        public void Delete(int id)
        {
            var saleDetails = _saleDetailsRepository.GetById(id);
            if (saleDetails == null)
            {
                throw new Exception("No hay un registro de venta con ese ID");
            }

            _saleDetailsRepository.Delete(saleDetails);
        }
    }
}
