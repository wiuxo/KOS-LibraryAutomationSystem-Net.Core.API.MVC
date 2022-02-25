using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Auth.Handlers.Queries;

public class GetRoles : IRequest<IResponse>
{
    public class GetRolesHandler : IRequestHandler<GetRoles, IResponse>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRolesHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IResponse> Handle(GetRoles request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetListAsync();
            if (!roles.Any()) return new Response<Role>(null, false, "There are no roles.");
            return new Response<IEnumerable<Role>>(roles);
        }
    }
}