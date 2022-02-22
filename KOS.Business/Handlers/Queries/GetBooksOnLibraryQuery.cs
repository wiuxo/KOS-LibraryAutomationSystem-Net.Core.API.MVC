using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries
{
    public class GetBooksOnLibraryQuery : IRequest<IResponse>
    {
        public class GetBooksOnLibraryQueryHandler : IRequestHandler<GetBooksOnLibraryQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetBooksOnLibraryQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetBooksOnLibraryQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetListAsync(x => x.HoldStatus == null && x.BorrowerID == null & x.IsRemoved != 1);
                if (!books.Any()) return new Response<Book>(null, false, "No book in library.");
                return new Response<IEnumerable<Book>>(books);
            }
        }
    }
}
