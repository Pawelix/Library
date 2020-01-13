using System.Collections.Generic;
using Pawel.Cms.Domain.Model;

namespace Pawel.Cms.Domain.Repositories
{
    public interface IBooksRepository
    {
        Book Get(int id);
        void Add(Book book);
        IEnumerable<Book> GetAll();
        void Update(Book book);
        void Delete(int id);
    }
}
