using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService 
    {
        User Authenticate(string UserName, string Password);
    }
}