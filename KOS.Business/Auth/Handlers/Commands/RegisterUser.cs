using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;
using System.Security.Cryptography;

namespace KOS.Business.Auth.Handlers.Commands;

public class RegisterUser : IRequest<IResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public class RegisterUserHandler : IRequestHandler<RegisterUser, IResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public RegisterUserHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public async Task<IResponse> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var checkUser = await _userRepository.GetAsync(x => x.UserName == request.UserName);
            if (checkUser != null) return new Response<User>(null, false, "A user with this username already exists.");
            CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            var newUser = new User();
            newUser.UserName = request.UserName;
            newUser.FirstName = request.FirstName;
            newUser.LastName = request.LastName;
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();

            var getRoleID = await _roleRepository.GetAsync(x => x.Name == "User");
            if (getRoleID == null)
            {
                var newRole = new Role();
                newRole.Name = "User";
                _roleRepository.Add(newRole);
                await _roleRepository.SaveChangesAsync();
                getRoleID = await _roleRepository.GetAsync(x => x.Name == "User");
            }

            var getnewUserID = await _userRepository.GetAsync(x => x.UserName == request.UserName);
            var newUserRole = new UserRole();
            newUserRole.RoleId = getRoleID.RoleId;
            newUserRole.UserID = getnewUserID.UserID;
            _userRoleRepository.Add(newUserRole);
            await _userRoleRepository.SaveChangesAsync();

            return new Response<User>(newUser);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}