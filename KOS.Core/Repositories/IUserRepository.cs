using KOS.Entities.DTOs;
using KOS.Entities.Models;

namespace KOS.Core.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> FindByUNameAsync(string userName);
    Task<IEnumerable<UserWithRolesDto>> GetUserRoleNames(int userId);
    List<UserWithRolesDto> GetUserRoleNamesList(int userId);
}