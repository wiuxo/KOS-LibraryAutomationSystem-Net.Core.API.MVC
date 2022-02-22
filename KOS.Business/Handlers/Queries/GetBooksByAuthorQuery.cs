using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries
{
    public class GetBooksByAuthorQuery : IRequest<IResponse>
    {
        public string Author { get; set; }
        public class GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetBooksByAuthorQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetListAsync(x => x.Author == request.Author && x.IsRemoved != 1);
                if (!books.Any()) return new Response<Book>(null, false, "No book from this author.");
                return new Response<IEnumerable<Book>>(books);
            }
        }
    }
}
