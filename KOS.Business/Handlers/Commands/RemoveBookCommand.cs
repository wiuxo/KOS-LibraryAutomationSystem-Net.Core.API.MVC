using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;

namespace KOS.Business.Handlers.Commands;

public class RemoveBookCommand : IRequest<IResponse>
{
    public int BookID { get; set; }

    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public RemoveBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var removeBook = await _bookRepository.GetAsync(x => x.BookID == request.BookID);
            if (removeBook == null || removeBook.IsRemoved == 1)
                return new Response<Book>(null, false, "There is no book by this ID.");
            removeBook.IsRemoved = 1;
            removeBook.BorrowerID = null;
            removeBook.HoldStatus = null;
            removeBook.ReturnedOnHold = 0;
            _bookRepository.Update(removeBook);
            await _bookRepository.SaveChangesAsync();

            return new Response<Book>(removeBook, true, "Removed.");
        }
    }
}