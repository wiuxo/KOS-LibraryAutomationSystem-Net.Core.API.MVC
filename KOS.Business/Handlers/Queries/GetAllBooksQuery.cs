using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries
{
    public class GetAllBooksQuery : IRequest<IResponse>
    {
        public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetAllBooksQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetListAsync(x => x.IsRemoved != 1);
                if (!books.Any()) return new Response<Book>(null, false, "No Books");

                return new Response<IEnumerable<Book>>(books);
            }
        }
    }
}
