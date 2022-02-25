using KOS.Core.Repositories;
using KOS.Core.Wrapper;
using KOS.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Business.Handlers.Commands;

public class BringBackRemovedBookCommand : IRequest<IResponse>
{
    public int BookID { get; set; }

    public class BringBackRemovedBookCommandHandler : IRequestHandler<BringBackRemovedBookCommand, IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public BringBackRemovedBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(BringBackRemovedBookCommand request, CancellationToken cancellationToken)
        {
            var removedBook = await _bookRepository.GetAsync(x => x.BookID == request.BookID);
            if (removedBook == null || removedBook.IsRemoved == 0)
                return new Response<Book>(null, false, "There is no removed book by this ID.");
            removedBook.IsRemoved = 0;
            _bookRepository.Update(removedBook);
            await _bookRepository.SaveChangesAsync();

            return new Response<Book>(removedBook, true, "Book is returned back.");
        }
    }
}