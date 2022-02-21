using KOS.Core.Repositories;
using KOS.Entities.Models;

namespace KOS.DAL.Repositories
{
    public class BookRepository : GenericRepository<Book, AppDbContext>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
