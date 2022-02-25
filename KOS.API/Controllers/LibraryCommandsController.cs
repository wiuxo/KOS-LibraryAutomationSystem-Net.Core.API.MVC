using KOS.Business.Handlers.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KOS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryCommandsController : BaseApiController
{
    [HttpPost("AddBook")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] AddBookCommand addBook)
    {
        return Created("", await Mediator.Send(addBook));
    }

    [HttpPut("BorrowBook")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] BorrowBookCommand borrowBookCommand)
    {
        return Ok(await Mediator.Send(borrowBookCommand));
    }

    [HttpPut("ReserveBook")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] HoldBookCommand holdBookCommand)
    {
        return Ok(await Mediator.Send(holdBookCommand));
    }

    [HttpPut("RemoveBook")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] RemoveBookCommand removeBookCommand)
    {
        return Ok(await Mediator.Send(removeBookCommand));
    }

    [HttpPut("BringBackRemovedBook")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] BringBackRemovedBookCommand removeBookCommand)
    {
        return Ok(await Mediator.Send(removeBookCommand));
    }

    [HttpPut("ReturnBook")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] ReturnBookCommand returnBookCommand)
    {
        return Ok(await Mediator.Send(returnBookCommand));
    }
}