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

        public SaleServices(ISaleRepository saleRepository, ISaleDetailsRepository saleDetailsRepository)
        {
            _saleRepository = saleRepository;
            _saleDetailsRepository = saleDetailsRepository;
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
            return new SaleDto
            {
                Id = sale.Id,
                DateTime = sale.DateTime,
                TotalSaleAmount = sale.TotalSaleAmount,
                ProductSale = sale.ProductSale,
                Amount = sale.Amount,
            };
        }

        public void Create(SaleCreateRequest request)
        {
            

            var sale = new Sale(request.DateTime, request.TotalSaleAmount, request.ProductSale, request.Amount,request.SaleDetails);
            
            var saleDetails = new List<SaleDetails>();
            foreach (var saleDetailId in request.SaleDetails)
            {
                var saleDetail = _saleDetailsRepository.GetById(saleDetailId);
                if (saleDetail != null)
                {
                    saleDetails.Add(saleDetail);
                }
            }

            
            sale.AddSaleDetails(saleDetails);

           
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
            sale.ProductSale = request.ProductSale;
            sale.Amount = request.Amount;

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
    }
}
