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
    public class AddBookCommand : IRequest<IResponse>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Subject { get; set; }

        public class AddBookCommandHandler : IRequestHandler<AddBookCommand, IResponse>
        {
            private readonly IBookRepository _bookRepository;

            public AddBookCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<IResponse> Handle(AddBookCommand request, CancellationToken cancellationToken)
            {
                Book newBook = new Book();
                newBook.Title = request.Title;
                newBook.Author = request.Author;
                newBook.Genre = request.Genre;
                newBook.Subject = request.Subject;

                _bookRepository.Add(newBook);
                await _bookRepository.SaveChangesAsync();
                return new Response<Book>(newBook);
            }
        }
    }
}
