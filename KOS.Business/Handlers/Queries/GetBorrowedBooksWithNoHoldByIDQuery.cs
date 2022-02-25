using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries
{
    public class GetBorrowedBooksWithNoHoldByIDQuery : IRequest<IResponse>
    {
        public int UserID { get; set; }
        public class GetBorrowedBooksWithNoHoldByIDQueryHandler : IRequestHandler<GetBorrowedBooksWithNoHoldByIDQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetBorrowedBooksWithNoHoldByIDQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetBorrowedBooksWithNoHoldByIDQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetListAsync(x => x.HoldStatus == null && x.BorrowerID == request.UserID && x.IsRemoved != 1);
                if (!books.Any()) return new Response<Book>(null, false, "No book in library.");
                return new Response<IEnumerable<Book>>(books);
            }
        }
    }
}