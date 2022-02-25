using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries;

public class GetReturnedOnHoldBooksQuery : IRequest<IResponse>
{
    public class GetReturnedOnHoldBooksQueryHandler : IRequestHandler<GetReturnedOnHoldBooksQuery, IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetReturnedOnHoldBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(GetReturnedOnHoldBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetListAsync(x => x.ReturnedOnHold == 1 && x.IsRemoved != 1);
            if (!books.Any()) return new Response<Book>(null, false, "No returned books that is reserved.");
            return new Response<IEnumerable<Book>>(books);
        }
    }
}