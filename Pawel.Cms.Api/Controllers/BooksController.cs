using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pawel.Cms.Common.DTOs;
using Pawel.Cms.Domain.Services.Interfaces;

namespace Pawel.Cms.Api.Controllers
{
    /// <summary>
    ///  Books Controller 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        /// <summary>
        /// Books Controller ctor
        /// </summary>
        /// <param name="booksService"></param>
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
       
        /// <summary>
        /// Get All books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Get()
        {
            return Ok(_booksService.GetAll());
        }

        /// <summary>
        ///  Metoda zwracajaca książke o podanym ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BookDTO</returns>
        [HttpGet("{id}")]
        public ActionResult<BookDTO> Get(int id)
        {
            var result = _booksService.GetBook(id);
            if (result == null)
                return NotFound($"nie znaleziono ksiazki o id: {id}");
            
            return Ok(result);
        }

        /// <summary>
        /// POST api/books
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public void Post([FromBody] BookDTO model)
        {           
             _booksService.AddBook(model.Title, model.Author);
        }

        /// <summary>
        /// PUT api/books/5
        /// </summary>
        /// <param name="model"></param>
        [HttpPut]        
        public void Put([FromBody] BookDTO model)
        {
            _booksService.UpdateBook(model);
        }
      
        /// <summary>
        /// DELETE api/books/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _booksService.DeleteBook(id);
        }
    }
}
