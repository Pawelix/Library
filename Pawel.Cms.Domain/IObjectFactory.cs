using System;
using System.Collections.Generic;
using System.Text;
using Pawel.Cms.Domain.Model;
using Pawel.Cms.Domain.Services.Interfaces;

namespace Pawel.Cms.Domain
{
    public interface IObjectFactory 
    {
        Book CreateBook(string title);
        Book CreateNewspaper(string title, string author);
    }
}
