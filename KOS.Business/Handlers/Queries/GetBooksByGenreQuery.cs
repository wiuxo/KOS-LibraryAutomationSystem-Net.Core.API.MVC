using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries;

public class GetBooksByGenreQuery : IRequest<IResponse>
{
    public string Genre { get; set; }

    public class GetBooksByGenreQueryHandler : IRequestHandler<GetBooksByGenreQuery, IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksByGenreQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(GetBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetListAsync(x => x.Genre == request.Genre && x.IsRemoved != 1);
            if (!books.Any()) return new Response<Book>(null, false, "No book in this genre.");
            return new Response<IEnumerable<Book>>(books);
        }
    }
}