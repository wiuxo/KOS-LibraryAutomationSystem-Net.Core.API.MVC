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
    public class HoldBookCommand : IRequest<IResponse>
    {
        public int BookID { get; set; }
        public int UserID { get; set; }
        public class HoldBookCommandHandler : IRequestHandler<HoldBookCommand, IResponse>
        {
            private readonly IBookRepository _bookRepository;

            public HoldBookCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            // needs conditions to be applies
            public async Task<IResponse> Handle(HoldBookCommand request, CancellationToken cancellationToken)
            {
                Book holdBook = _bookRepository.Get(x => x.BookID == request.BookID);

                holdBook.HoldStatus = request.UserID;
                _bookRepository.Update(holdBook);
                await _bookRepository.SaveChangesAsync();
                return new Response<Book>(holdBook);
            }
        }
    }
}
