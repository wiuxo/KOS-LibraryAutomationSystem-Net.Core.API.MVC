using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Auth.Handlers.Commands
{
    public class RemoveUser : IRequest<IResponse>
    {
        public int UserId { get; set; }
        public class RemoveUserHandler : IRequestHandler<RemoveUser, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserRoleRepository _userRoleRepository;
            public RemoveUserHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
            {
                _userRepository = userRepository;
                _userRoleRepository = userRoleRepository;
            }

            public async Task<IResponse> Handle(RemoveUser request, CancellationToken cancellationToken)
            {
                var removedUser = await _userRepository.GetAsync(x => x.UserID == request.UserId);
                var removedRole= await _userRoleRepository.GetListAsync(x => x.UserID == request.UserId );
                if (removedUser == null) return new Response<User>(null, false, "A user with this ID doesn't exist.");
                _userRepository.Remove(removedUser);
                foreach (var item in removedRole )
                {
                    _userRoleRepository.Remove(item);
                }
                await _userRoleRepository.SaveChangesAsync();
                await _userRepository.SaveChangesAsync();
                return new Response<User>(removedUser);
            }
        }

    }
}
