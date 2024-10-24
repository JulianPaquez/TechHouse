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



        public List<SaleDetailsDto> GetAll()
        {
            var list = _saleDetailsRepository.GetAll();
            return SaleDetailsDto.CreateList(list);
        }

        public SaleDetailsDto GetById(int id)
        {
            var details = _saleDetailsRepository.GetById(id);
            if (details == null)
            {
                throw new Exception("Detalle de la venta no encontrado");
            }

            // Solo devuelve el ID del SaleDetails
            return new SaleDetailsDto
            {
                Id = details.Id,
                SaleId = details.SaleId,
                ProductId = details.ProductId,
            };
        }

        public void Create(SaleDetailsCreateRequest request)
        {
            var productFound = _productRepository.GetById(request.ProductId);
            var saleFound = _saleRepository.GetById(request.SaleId);

            if (productFound == null || saleFound == null)
            {
                throw new Exception("Producto o venta no encontrado");
            }

            // Crear una nueva instancia de SaleDetails sin asignar manualmente el Id
            var saleDetails = new SaleDetails
            {
                Sale= saleFound,
                Product = productFound,
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
