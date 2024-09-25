using Application;
using Application.Request;
using Domain.Entities;

namespace Appication.Interfaces;

public interface ISysAdminService
{
    List<SysAdminDto> GetAll();
    SysAdminDto GetById(int id);
    SysAdmin Create(SysAdminCreateRequest request);
    void Update(int id, SysAdminUpdateRequest request);
    void Delete(int id);
}