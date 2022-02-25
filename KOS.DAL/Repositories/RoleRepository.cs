using KOS.Core.Repositories;
using KOS.Entities.Models;

namespace KOS.DAL.Repositories;

public class RoleRepository : GenericRepository<Role, AppDbContext>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}