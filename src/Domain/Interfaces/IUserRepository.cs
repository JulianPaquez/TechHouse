using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User ? GetByUsername(string UserName);
    }
}