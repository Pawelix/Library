using System.Collections.Generic;
using System.Linq;
using Pawel.Cms.Domain.Context;
using Pawel.Cms.Domain.Model;

namespace Pawel.Cms.Domain.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly CmsDBContext _dbContext;

        public BooksRepository(CmsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Book book)
        {
            _dbContext.Set<Book>().Add(book);
            _dbContext.SaveChanges();
        }

        public Book Get(int id)
        {
            return _dbContext.Find<Book>(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public void Delete(int id)
        {
            var book = _dbContext.Find<Book>(id);
            _dbContext.Remove(book);
            _dbContext.SaveChanges();
        }

        public void Update(Book book)
        {
            _dbContext.Set<Book>().Update(book);
            _dbContext.SaveChanges();
        }
    }
}
