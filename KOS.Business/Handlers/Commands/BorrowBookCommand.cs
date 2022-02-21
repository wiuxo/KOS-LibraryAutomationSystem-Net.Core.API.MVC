using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Business.Handlers.Commands
{
    public class BorrowBookCommand : IRequest<IResponse>
    {
        public int BookID { get; set; }
        public int UserID { get; set; }
        public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, IResponse>
        {
            private readonly IBookRepository _bookRepository;
            public BorrowBookCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            // needs conditions to be applies
            public async Task<IResponse> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
            {
                Book borrowBook = _bookRepository.Get(x => x.BookID == request.BookID);
                
                borrowBook.BorrowerID = request.UserID;
                _bookRepository.Update(borrowBook);
                await _bookRepository.SaveChangesAsync();
                return new Response<Book>(borrowBook);
            }
        }
    }
}
