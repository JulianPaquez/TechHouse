namespace Infrastructure.Repositories
{
    public class EfRepository<T> : BaseRepository<T> where T : class
    {
        protected new readonly ApplicationContext _context;
        public EfRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}