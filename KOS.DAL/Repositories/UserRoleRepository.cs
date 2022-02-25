using KOS.Core.Repositories;
using KOS.Entities.Models;

namespace KOS.DAL.Repositories;

public class UserRoleRepository : GenericRepository<UserRole, AppDbContext>, IUserRoleRepository
{
    private readonly AppDbContext _context;

    public UserRoleRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}