

using Appication.Interfaces;
using Application.Request;
using Domain;
using Domain.Entities;

namespace Application.Service;

public class SysAdminService : ISysAdminService
{
    private readonly ISysAdminRepository _sysAdminRepository;
    public SysAdminService(ISysAdminRepository sysAdminRepository)
    {
        _sysAdminRepository = sysAdminRepository;
    }

    public SysAdmin Create(SysAdminCreateRequest request)
{
    var newSysAdmin = new SysAdmin(request.Name, request.LastName,request.Email, request.Password);
    _sysAdminRepository.Create(newSysAdmin); 
    return newSysAdmin; 
}


    public void Update(int id,SysAdminUpdateRequest request)
    {
        var sysAdmin = _sysAdminRepository.GetById(id);
        if(sysAdmin != null) 
        {
            sysAdmin.Name = request.Name;
            sysAdmin.LastName = request.LastName;
            sysAdmin.Email = request.Email;

            _sysAdminRepository.Update(sysAdmin);
        }
    }

    public SysAdminDto GetById(int id)
    {
        
        
         var sysAdmin = _sysAdminRepository.GetById(id);
           if(sysAdmin != null)
        {
            return new SysAdminDto
                { 
                    Id = sysAdmin.Id,
                    Name = sysAdmin.Name,
                    LastName = sysAdmin.LastName,
                    Email = sysAdmin.Email,
                };
        }
        return null;
         
    }

    public List<SysAdminDto> GetAll()
    {
        var list = _sysAdminRepository.GetAll();
        return SysAdminDto.CreateList(list);
    }

    public void Delete(int id)
    {
        var sysAdmin = _sysAdminRepository.GetById(id );
        if(sysAdmin != null)
        {
            _sysAdminRepository.Delete(sysAdmin);
        }
    }
}