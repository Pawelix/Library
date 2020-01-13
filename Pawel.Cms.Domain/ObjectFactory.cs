using System;
using System.Collections.Generic;
using System.Text;
using Pawel.Cms.Domain.Model;

namespace Pawel.Cms.Domain
{
    public class ObjectFactory : IObjectFactory
    {
        public Book CreateBook(string title)
        {
            return new Book(title);
        }

        public Book CreateNewspaper(string title,string author)
            => new Book(title, author);
    }
}
