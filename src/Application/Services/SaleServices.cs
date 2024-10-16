using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SaleServices : ISaleServices
    {
        private readonly ISaleRepository _saleRepository;
        public SaleServices(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public List<SaleDto> GetAll() 
        {
            var list = _saleRepository.GetAll();
            return SaleDto.CreateList(list);
        }
        public SaleDto GetById(int id) 
        {
            var sale = _saleRepository.GetById(id);
            if(sale == null) 
            {
                throw new Exception("Venta no encontrado");
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
        public Sale Create(SaleCreateRequest request)
        {
            var newSale = new Sale(request.DateTime, request.TotalSaleAmount, request.ProductSale, request.Amount);
            _saleRepository.Create(newSale);
            return newSale;
        }
        public void Update(int id,SaleUpdateRequest request)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null)
            {
                throw new Exception("Venta no encontrado");
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
                throw new Exception("Venta no encontrado");
            }
            _saleRepository.Delete(sale);
        }
    }
}
