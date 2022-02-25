using KOS.Business.Handlers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KOS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryQueriesController : BaseApiController
{
    [HttpGet("GetAllBooks")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetList()
    {
        return Ok(await Mediator.Send(new GetAllBooksQuery()));
    }

    [HttpGet("GetBookById")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> Get(int BookID)
    {
        return Ok(await Mediator.Send(new GetBookByIdQuery() {BookID = BookID}));
    }

    [HttpGet("GetBookByTitle")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> Get(string Title)
    {
        return Ok(await Mediator.Send(new GetBookByTitleQuery() {Title = Title}));
    }

    [HttpGet("GetBookByAuthor")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetList(string Author)
    {
        return Ok(await Mediator.Send(new GetBooksByAuthorQuery() {Author = Author}));
    }

    [HttpGet("GetBookByGenre")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetListGenre(string Genre)
    {
        return Ok(await Mediator.Send(new GetBooksByGenreQuery() {Genre = Genre}));
    }

    [HttpGet("GetReservedBooks")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetReservedBooksList()
    {
        return Ok(await Mediator.Send(new GetBooksOnHoldQuery()));
    }

    [HttpGet("GetBooksOnLibrary")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetBooksOnLibrary()
    {
        return Ok(await Mediator.Send(new GetBooksOnLibraryQuery()));
    }

    [HttpGet("GetReturnedReservedBooks")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetReturnedReservedBooks()
    {
        return Ok(await Mediator.Send(new GetReturnedOnHoldBooksQuery()));
    }

    [HttpGet("GetRemovedBooks")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetRemovedBooks()
    {
        return Ok(await Mediator.Send(new GetRemovedBooksQuery()));
    }

    [HttpGet("GetReservedBooksByUserId")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetReservedBooksByUserId(int UserID)
    {
        return Ok(await Mediator.Send(new GetReservedBooksByUserIdQuery() {UserID = UserID}));
    }

    [HttpGet("GetBorrowedBooksWithNoHoldByUserID")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetBorrowedBooksWithNoHoldByUserId(int UserID)
    {
        return Ok(await Mediator.Send(new GetBorrowedBooksWithNoHoldByIDQuery() {UserID = UserID}));
    }

    [HttpGet("GetBorrowedAndReservedBooksQuery")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetBorrowedAndReservedBooksQuery()
    {
        return Ok(await Mediator.Send(new GetBorrowedAndReservedBooksQuery()));
    }

    [HttpGet("GetBorrowedBooksWithNoHold")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetBorrowedBooksWithNoHold()
    {
        return Ok(await Mediator.Send(new GetBorrowedBooksWithNoHoldQuery()));
    }
}