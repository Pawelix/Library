using Pawel.Cms.Domain.Services.Interfaces;
using Pawel.Cms.Common.DTOs;
using Pawel.Cms.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Pawel.Cms.Domain.Services.Implementation
{
    public class BooksService : IBooksService
    {
        private readonly IObjectFactory _objectFactory;
        private readonly IBooksRepository _booksRepository;

        public BooksService(IObjectFactory objectFactory, IBooksRepository booksRepository)
        {
            _objectFactory = objectFactory;
            _booksRepository = booksRepository;
        }

        public void AddBook(string title, string author)
        {
            var book = _objectFactory.CreateNewspaper(title, author);
            _booksRepository.Add(book);
        }

        public BookDTO GetBook(int id)
        {
            var book = _booksRepository.Get(id);

            if (book == null)
                return null;

            return new BookDTO
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title
            };          
        }

        public IEnumerable<BookDTO> GetAll()
        {
            return _booksRepository.GetAll().Select(x => new BookDTO
            {
                Author = x.Author,
                Id = x.Id,
                Title = x.Title
            });
        }

        public void UpdateBook(BookDTO book)
        {          
            _booksRepository.Update(new Model.Book
            {
                Author = book.Author,
                Title = book.Title,
                Id = book.Id
            });
        }

        public void DeleteBook(int id)
        {
            _booksRepository.Delete(id);
        }
    }
}


// var test = book.GetBookType().GetXXX<DisplayAttribute>().Name;