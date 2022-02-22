using KOS.Business.Auth.Handlers.Commands;
using KOS.Business.Auth.Handlers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {

        [HttpGet("LogIn")]
        public async Task<IActionResult> GetByUname(string Username, string Password)
        {
            return Ok(await Mediator.Send(new LoginUser() { UserName = Username, Password = Password }));
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> Add([FromBody] RegisterUser createUser)
        {
            return Created("", await Mediator.Send(createUser));
        }
        [HttpDelete("DeleteUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove([FromBody] RemoveUser removeUser)
        {
            return Ok(await Mediator.Send(removeUser));
        }
        [HttpGet("GetUserRolesByUserID")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserRoleNames(int userId)
        {
            return Ok(await Mediator.Send(new GetRolesByUserId() { UserId = userId }));
        }
        [HttpPost("AddUserRole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] AddUserRole newUserRole)
        {
            return Created("", await Mediator.Send(newUserRole));
        }
        [HttpDelete("DeleteUserRole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove([FromBody] RemoveUserRole removeUserRole)
        {
            return Ok(await Mediator.Send(removeUserRole));
        }
        [HttpGet("GetRoles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await Mediator.Send(new GetRoles()));
        }
    }
}
