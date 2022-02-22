using KOS.Business.Handlers.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryQueriesController : BaseApiController
    {
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await Mediator.Send(new GetAllBooksQuery()));
        }
        [HttpGet("GetBookById")]
        public async Task<IActionResult> Get(int BookID)
        {
            return Ok(await Mediator.Send(new GetBookByIdQuery() { BookID = BookID }));
        }
        [HttpGet("GetBookByTitle")]
        public async Task<IActionResult> Get(string Title)
        {
            return Ok(await Mediator.Send(new GetBookByTitleQuery() { Title = Title }));
        }
        [HttpGet("GetBookByAuthor")]
        public async Task<IActionResult> GetList(string Author)
        {
            return Ok(await Mediator.Send(new GetBooksByAuthorQuery() { Author = Author }));
        }
        [HttpGet("GetBookByGenre")]
        public async Task<IActionResult> GetListGenre(string Genre)
        {
            return Ok(await Mediator.Send(new GetBooksByGenreQuery() { Genre = Genre }));
        }
        [HttpGet("GetReservedBooks")]
        public async Task<IActionResult> GetReservedBooksList()
        {
            return Ok(await Mediator.Send(new GetBooksOnHoldQuery()));
        }
        [HttpGet("GetBooksOnLibrary")]
        public async Task<IActionResult> GetBooksOnLibrary()
        {
            return Ok(await Mediator.Send(new GetBooksOnLibraryQuery()));
        }
        [HttpGet("GetReturnedReservedBooks")]
        public async Task<IActionResult> GetReturnedReservedBooks()
        {
            return Ok(await Mediator.Send(new GetReturnedOnHoldBooksQuery()));
        }
        [HttpGet("GetRemovedBooks")]
        public async Task<IActionResult> GetRemovedBooks()
        {
            return Ok(await Mediator.Send(new GetRemovedBooksQuery()));
        }
    }
}
