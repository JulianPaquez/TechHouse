
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
        var newAdmin = new Admin(request.Name, request.Username, request.Password);

        _adminRepository.Create(newAdmin);

        return newAdmin;
    }

    public void Update(int id, AdminUpdateRequest request)
    {
        var Admin = _adminRepository.GetById(id);
        if (Admin != null)
        {
            Admin.Name = request.Name;
            Admin.Username = request.Username;
            Admin.Password = request.Password;

            _adminRepository.Update(Admin);
        }
    }
    public AdminDto GetById(int id)
    {


        var Admin = _adminRepository.GetById(id);
        if (Admin != null)
        {
            return new AdminDto
            {
                Id = Admin.Id,
                Name = Admin.Name,
                Username = Admin.Username,
                Password = Admin.Password,
            };
        }
        return null;

    }

    public List<AdminDto> GetAll()
    {
        var list = _adminRepository.GetAll();
        return AdminDto.CreateList(list);
    }

    public void Delete(int id)
    {
        var admin = _adminRepository.GetById(id);
        if (admin != null)
        {
            _adminRepository.Delete(admin);
        }
    }
}