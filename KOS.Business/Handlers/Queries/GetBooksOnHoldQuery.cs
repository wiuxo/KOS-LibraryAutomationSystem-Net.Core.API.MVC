using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries;

public class GetBooksOnHoldQuery : IRequest<IResponse>
{
    public class GetBooksOnHoldQueryHandler : IRequestHandler<GetBooksOnHoldQuery, IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksOnHoldQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(GetBooksOnHoldQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetListAsync(x => x.HoldStatus != null && x.IsRemoved != 1);
            return !books.Any()
                ? new Response<Book>(null, false, "No reserved books.")
                : new Response<IEnumerable<Book>>(books);
        }
    }
}