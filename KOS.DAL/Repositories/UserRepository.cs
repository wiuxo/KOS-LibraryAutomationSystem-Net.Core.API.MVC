using KOS.Core.Repositories;
using KOS.Entities.Models;

namespace KOS.DAL.Repositories
{
    public class UserRepository : GenericRepository<User, AppDbContext>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
