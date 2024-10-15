using Domain.Entities;
using Domain.Interfaces;



namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
        public User? GetByUsername(string username)
        {
            return _context.Users.SingleOrDefault(p => p.Username == username);
        }
    

    }
}