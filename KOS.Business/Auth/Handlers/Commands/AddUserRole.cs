using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Auth.Handlers.Commands
{
    public class AddUserRole : IRequest<IResponse>
    {
        public int userID { get; set; }
        public int roleID { get; set; }
        public class AddUserRoleHandler : IRequestHandler<AddUserRole, IResponse>
        {
            private readonly IUserRoleRepository _userRoleRepository;
            private readonly IRoleRepository _roleRepository;
            private readonly IUserRepository _userRepository;

            public AddUserRoleHandler(IUserRoleRepository userRoleRepository, IRoleRepository roleRepository, IUserRepository userRepository)
            {

                _userRoleRepository = userRoleRepository;
                _roleRepository = roleRepository;

            }
            public async Task<IResponse> Handle(AddUserRole request, CancellationToken cancellationToken)
            {
                var checkRole = await _roleRepository.GetAsync(x => x.RoleId == request.roleID);
                var checkUserRole = await _userRoleRepository.GetAsync(x => x.RoleId == request.roleID && x.UserID == request.userID);
                var checkUser = await _userRepository.GetAsync(x => x.UserID == request.userID);

                if (checkRole == null) return new Response<UserRole>(null, false, "A role with this ID doesn't exist.");
                else if (checkUser == null) return new Response<UserRole>(null, false, "A user with this ID doesn't exist.");
                else if (checkUserRole != null) return new Response<UserRole>(null, false, "This user already has this role.");

                var newUserRole = new UserRole();
                newUserRole.UserID = request.userID;
                newUserRole.RoleId = request.roleID;
                _userRoleRepository.Add(newUserRole);
                await _userRoleRepository.SaveChangesAsync();

                return new Response<UserRole>(newUserRole);
            }
        }
    }
}
