using KOS.Core.Constants;
using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries
{
    public class GetBookByTitleQuery : IRequest<IResponse>
    {
        public string Title { get; set; }
        public class GetBookByTitleQueryHandler : IRequestHandler<GetBookByTitleQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetBookByTitleQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetBookByTitleQuery request, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetAsync(x => x.Title == request.Title && x.IsRemoved != 1);
                if (book is null) return new Response<Book>(null, false, "No book by this title.");
                return new Response<Book>(book);
            }
        }
    }
}
