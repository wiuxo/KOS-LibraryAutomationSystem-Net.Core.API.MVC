using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Auth.Handlers.Commands;

public class RemoveUserRole : IRequest<IResponse>
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public class RemoveUserRoleHandler : IRequestHandler<RemoveUserRole, IResponse>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public RemoveUserRoleHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<IResponse> Handle(RemoveUserRole request, CancellationToken cancellationToken)
        {
            var removeUserRole =
                await _userRoleRepository.GetAsync(x => x.UserID == request.UserId && x.RoleId == request.RoleId);
            if (removeUserRole == null)
                return new Response<UserRole>(null, false, "A user with this ID and role doesn't exist.");
            _userRoleRepository.Remove(removeUserRole);
            await _userRoleRepository.SaveChangesAsync();
            return new Response<UserRole>(removeUserRole);
        }
    }
}