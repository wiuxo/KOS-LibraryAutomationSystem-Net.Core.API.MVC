using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries
{
    public class GetBookByIdQuery : IRequest<IResponse>
    {
        public int BookID { get; set; }
        public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetBookByIdQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetAsync(x => x.BookID == request.BookID && x.IsRemoved != 1);
                return book == null ? new Response<Book>(null, false, "No book with with id.") 
                                    : new Response<Book>(book);
            }
        }
    }
}