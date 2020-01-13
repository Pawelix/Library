using System.Collections.Generic;
using Pawel.Cms.Common.DTOs;

namespace Pawel.Cms.Domain.Services.Interfaces
{
    public interface IBooksService
    {
        void AddBook(string title, string author);
        BookDTO GetBook(int id);
        IEnumerable<BookDTO> GetAll();
        void DeleteBook(int id);
        void UpdateBook(BookDTO book);
    }
}
