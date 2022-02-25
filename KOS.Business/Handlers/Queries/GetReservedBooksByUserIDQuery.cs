using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Queries;

public class GetReservedBooksByUserIdQuery : IRequest<IResponse>
{
    public int UserID { get; set; }

    public class GetReservedBooksByUserIdHandler : IRequestHandler<GetReservedBooksByUserIdQuery, IResponse>
    {
        private readonly IBookRepository _bookRepository;
        public GetReservedBooksByUserIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IResponse> Handle(GetReservedBooksByUserIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetListAsync(x => x.HoldStatus == request.UserID && x.IsRemoved != 1 && x.BorrowerID == null);
            return !book.Any() ? new Response<IEnumerable<Book>>(null, false, "There is no reserved book for this user.") 
                               : new Response<IEnumerable<Book>>(book);
        }
    }
}