using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.DTOs;
using MediatR;

namespace KOS.Business.Auth.Handlers.Queries
{
    public class GetRolesByUserId : IRequest<IResponse>
    {
        public int UserId { get; set; }
        public class GetRolesByUserIdHandler : IRequestHandler<GetRolesByUserId, IResponse>
        {
            private readonly IUserRepository _userRepository;

            public GetRolesByUserIdHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<IResponse> Handle(GetRolesByUserId request, CancellationToken cancellationToken)
            {
                var roles = await _userRepository.GetUserRoleNames(request.UserId);
                if (!roles.Any()) return new Response<UserWithRolesDto>(null, false, "Either this user has no roles or doesn't exist.");
                return new Response<IEnumerable<UserWithRolesDto>>(roles);
            }
        }
    }
}
