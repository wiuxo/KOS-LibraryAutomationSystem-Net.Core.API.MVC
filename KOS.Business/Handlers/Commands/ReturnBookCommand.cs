using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Commands;

public class ReturnBookCommand : IRequest<IResponse>
{
    public int BookID { get; set; }
    public int UserID { get; set; }

    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public ReturnBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var returnBook = _bookRepository.Get(x => x.BookID == request.BookID && x.BorrowerID == request.UserID);
            if (returnBook == null) return new Response<Book>(null, false, "There is no matching borrowing process.");

            if (returnBook.HoldStatus != null) returnBook.ReturnedOnHold = 1;
            returnBook.BorrowerID = null;

            _bookRepository.Update(returnBook);
            await _bookRepository.SaveChangesAsync();
            return new Response<Book>(returnBook, true, "Book is successfully returned.");
        }
    }
}