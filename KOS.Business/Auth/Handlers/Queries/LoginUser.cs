using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.DTOs;
using KOS.Entities.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace KOS.Business.Auth.Handlers.Queries
{
    public class LoginUser : IRequest<IResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class LoginUserHandler : IRequestHandler<LoginUser, IResponse>
        {
            //private readonly IConfiguration _configuration;
            private readonly IUserRepository _userRepository;
            protected readonly IConfiguration _configuration;


            public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration)
            {
                _userRepository = userRepository;
                _configuration = configuration;
            }
            public async Task<IResponse> Handle(LoginUser request, CancellationToken cancellationToken)
            {
                var newUser = await _userRepository.GetAsync(x => x.UserName == request.UserName);

                if (newUser == null) return new Response<User>(null, false, "Wrong Username");
                else if (!VerifyPasswordHash(request.Password, newUser.PasswordHash, newUser.PasswordSalt))
                    return new Response<User>(newUser, false, "Wrong password");
                TokenDto newToken = new TokenDto();
                newToken.Token = CreateToken(newUser);
                return new Response<TokenDto>(newToken, true);
            }
            private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            {
                using (var hmac = new HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                    return computedHash.SequenceEqual(passwordHash);
                }
            }
            private string CreateToken(User user)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: GetClaims(user),
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:TokenValidityInMinutes"])),
                signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return jwt;
            }

            private IEnumerable<Claim> GetClaims(User user)
            {
                var claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
                };
                var roles = new List<UserWithRolesDto>(_userRepository.GetUserRoleNamesList(user.UserID));
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
                return claims;
            }

        }
    }
}










