using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Business.Handlers.Queries
{
    public class GetRemovedBooksQuery : IRequest<IResponse>
    {
        public class GetRemovedBooksQueryHandler : IRequestHandler<GetRemovedBooksQuery, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public GetRemovedBooksQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<IResponse> Handle(GetRemovedBooksQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetListAsync(x => x.IsRemoved == 1);
                if (!books.Any()) return new Response<Book>(null, false, "No removed books.");
                return new Response<IEnumerable<Book>>(books);
            }
        }
    }
}
