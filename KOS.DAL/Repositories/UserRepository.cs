using KOS.Core.Repositories;
using KOS.Entities.Models;

namespace KOS.DAL.Repositories
{
    public class UserRepository : GenericRepository<User, AppDbContext>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
