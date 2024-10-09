
using Appication.Interfaces;
using Application.Request;
using Domain;
using Domain.Entities;

namespace Application.Service;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public Admin Create(AdminCreateRequest request)
    {
        var newAdmin = new Admin(request.Name, request.Lastname, request.Username, request.Password, request.Email);

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