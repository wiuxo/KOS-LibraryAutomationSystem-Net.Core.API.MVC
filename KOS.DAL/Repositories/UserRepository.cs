using KOS.Core.Repositories;
using KOS.Entities.DTOs;
using KOS.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace KOS.DAL.Repositories
{
    public class UserRepository : GenericRepository<User, AppDbContext>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> FindByUNameAsync(string userName)
        {
            return await _context.Users.Include(u => u.UserRoles)
                                       .ThenInclude(ur => ur.Role)
                                       .SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<UserWithRolesDto>> GetUserRoleNames(int userId)
        {
            var result = await (from users in Context.Users
                                join userRoles in Context.UserRoles
                                on users.UserID equals userRoles.UserID
                                join role in Context.Roles
                                on userRoles.RoleId equals role.RoleId
                                where userRoles.UserID == userId
                                select new UserWithRolesDto()
                                {
                                    roleId = role.RoleId,
                                    Name = role.Name
                                }).ToListAsync();
            return result;
        }
        public List<UserWithRolesDto> GetUserRoleNamesList(int userId)
        {
            var result = (from users in Context.Users
                          join userRoles in Context.UserRoles
                          on users.UserID equals userRoles.UserID
                          join role in Context.Roles
                          on userRoles.RoleId equals role.RoleId
                          where userRoles.UserID == userId
                          select new UserWithRolesDto()
                          {
                              Name = role.Name
                          }).ToList();
            return result;
        }
    }
}
