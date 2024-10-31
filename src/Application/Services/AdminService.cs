
using Appication.Interfaces;
using Application.Models;
using Application.Request;
using Application.Services;
using Domain;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Service;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IClientService _clientService;
    private readonly IProductRepository _productService;
    public AdminService(IAdminRepository adminRepository, IClientService clientService, IProductRepository productService)
    {
        _adminRepository = adminRepository;
        _clientService = clientService;
        _productService = productService;
    }
    public Admin Create(AdminCreateRequest request)
    {
        var newAdmin = new Admin(request.Name, request.Lastname, request.Email, request.Password, request.Username);

        _adminRepository.Create(newAdmin);

        return newAdmin;
    }

    public void Update(int id, AdminUpdateRequest request)
    {
        var admin = _adminRepository.GetById(id);
        if (admin == null)
        {
            throw new Exception("Admin no encontrado");
        }
        admin.Name = request.Name;
        admin.LastName = request.Lastname;
        admin.Email = request.Email;
        admin.Password = request.Password;
        admin.Username = request.Username;

        _adminRepository.Update(admin);

    }
    public AdminDto GetById(int id)
    {


        var Admin = _adminRepository.GetById(id);
        if (Admin == null)
        {
            throw new Exception("Admin no encontrado");
        }
        return new AdminDto
        {
            Id = Admin.Id,
            Name = Admin.Name,
            Username = Admin.Username,
            Password = Admin.Password,
        };


    }


    public List<AdminDto> GetAll()
    {
        var list = _adminRepository.GetAll();
        return AdminDto.CreateList(list);
    }

    public void Delete(int id)
    {
        var admin = _adminRepository.GetById(id);
        if (admin == null)
        {

            throw new Exception("Admin no encontrado");
        }
        _adminRepository.Delete(admin);


    }
}