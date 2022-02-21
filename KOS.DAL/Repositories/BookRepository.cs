using KOS.Core.Repositories;
using KOS.Entities.Models;

namespace KOS.DAL.Repositories
{
    public class BookRepository : GenericRepository<Book, AppDbContext>, IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
