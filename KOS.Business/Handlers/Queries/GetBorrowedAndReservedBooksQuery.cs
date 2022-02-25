using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries
{
    public class GetBorrowedAndReservedBooksQuery : IRequest<IResponse>
    {
        public int UserID { get; set; }
        public class GetBorrowedAndReservedBooksQueryHandler : IRequestHandler<GetBorrowedAndReservedBooksQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetBorrowedAndReservedBooksQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetBorrowedAndReservedBooksQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetListAsync(x => x.HoldStatus != null && x.BorrowerID != null && x.IsRemoved != 1);
                if (!books.Any()) return new Response<Book>(null, false, "No book in library that is both borrowed and reserved.");
                return new Response<IEnumerable<Book>>(books);
            }
        }
    }
}