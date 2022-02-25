using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Commands;

public class BorrowBookCommand : IRequest<IResponse>
{
    public int BookID { get; set; }
    public int UserID { get; set; }

    public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, IResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BorrowBookCommandHandler(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<IResponse> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            var borrowBook = _bookRepository.Get(x => x.BookID == request.BookID);
            var borrowerUser = _userRepository.Get(x => x.UserID == request.UserID);
            if (borrowerUser == null) return new Response<Book>(null, false, "There is no user by this ID");
            else if (borrowBook == null || borrowBook.IsRemoved == 1)
                return new Response<Book>(null, false, "There is no book by this ID");
            else if (borrowBook.BorrowerID != null &&
                     borrowBook.HoldStatus != null)
                return new Response<Book>(borrowBook, false, "Book is already borrowed and reserved.");
            else if (borrowBook.BorrowerID != null)
                return new Response<Book>(borrowBook, false, "Book is already borrowed. You can reserve it");
            else if (borrowBook.HoldStatus != null &&
                     borrowBook.HoldStatus != request.UserID)
                return new Response<Book>(borrowBook, false, "Book is already reserved.");

            borrowBook.BorrowerID = request.UserID;
            borrowBook.HoldStatus = null;
            borrowBook.ReturnedOnHold = 0;
            _bookRepository.Update(borrowBook);
            await _bookRepository.SaveChangesAsync();
            return new Response<Book>(borrowBook, true, "Book borrowed.");
        }
    }
}