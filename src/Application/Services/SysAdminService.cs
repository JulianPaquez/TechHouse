

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
        var newSysAdmin = new SysAdmin(request.Name, request.LastName, request.Email, request.Password, request.Username);

        // Crea el SysAdmin en el repositorio
        _sysAdminRepository.Create(newSysAdmin); 
    
        // Devuelve el SysAdmin creado
        return newSysAdmin; 
    }


    public void Update(int id,SysAdminUpdateRequest request)
    {
        var sysAdmin = _sysAdminRepository.GetById(id);
        if(sysAdmin == null) 
        {
            throw new Exception("SysAdmin no encontrado");
        }
        sysAdmin.Name = request.Name;
        sysAdmin.LastName = request.LastName;
        sysAdmin.Email = request.Email;

        _sysAdminRepository.Update(sysAdmin);
    }

    public SysAdminDto GetById(int id)
    {
        
        
         var sysAdmin = _sysAdminRepository.GetById(id);
        if (sysAdmin == null)
        {
            throw new Exception("SysAdmin no encontrado");
        }
        return new SysAdminDto
        {
            Id = sysAdmin.Id,
            Name = sysAdmin.Name,
            LastName = sysAdmin.LastName,
            Email = sysAdmin.Email,
        };
         
    }

    public List<SysAdminDto> GetAll()
    {
        var list = _sysAdminRepository.GetAll();
        return SysAdminDto.CreateList(list);
    }

    public void Delete(int id)
    {
      var sysAdmin = _sysAdminRepository.GetById(id);
        if (sysAdmin == null)
        {

            throw new Exception("Admin no encontrado");
        }
        _sysAdminRepository.Delete(sysAdmin);
    }
}