using Application;
using Application.Models;
using Application.Request;
using Domain.Entities;

namespace Appication.Interfaces;

public interface IAdminService
{
    List<AdminDto> GetAll();
    AdminDto GetById(int id);
    Admin Create(AdminCreateRequest request);
    void Update(int id, AdminUpdateRequest request);
    void Delete(int id);

}