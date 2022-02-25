using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Commands;

public class HoldBookCommand : IRequest<IResponse>
{
    public int BookID { get; set; }
    public int UserID { get; set; }

    public class HoldBookCommandHandler : IRequestHandler<HoldBookCommand, IResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public HoldBookCommandHandler(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<IResponse> Handle(HoldBookCommand request, CancellationToken cancellationToken)
        {
            var holdBook = _bookRepository.Get(x => x.BookID == request.BookID);
            var holderUser = _userRepository.Get(x => x.UserID == request.UserID);

            if (holderUser == null) return new Response<Book>(null, false, "There is no user by this ID.");
            if (holdBook == null) return new Response<Book>(null, false, "There is no book by this ID.");
            if (holdBook.HoldStatus != null) return new Response<Book>(holdBook, false, "Book is already reserved.");
            holdBook.HoldStatus = request.UserID;
            _bookRepository.Update(holdBook);
            await _bookRepository.SaveChangesAsync();
            return new Response<Book>(holdBook, true, "Book is successfully reserved.");
        }
    }
}