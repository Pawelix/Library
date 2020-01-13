using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using Pawel.Cms.Common.DTOs;
using Pawel.Cms.External.Api;

namespace Pawel.Cms.Web.Controllers
{
    public class BookController : Controller
    {
        readonly CmsApiClient _cmsApiClient;

        public BookController(CmsApiClient cmsApiClient)
        {
            _cmsApiClient = cmsApiClient;
        }

        // GET: Book
        public ActionResult Index()
        {
            var result = _cmsApiClient.ApiBooksGet().Select(x=> new BookDTO {
                Author = x.Author,
                Id = x.Id.Value,
                Title = x.Title
            });
            return View(result);
        }

        // GET: Book/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var book = await _cmsApiClient.ApiBooksByIdGetAsync(id);
                return View(new BookDTO
                {
                    Author = book.Author,
                    Title = book.Title,
                    Id = book.Id.Value
                });
            }
            catch (HttpOperationException ex)
            {
                var test = ex;
                ViewBag.result = ex.Response.Content;
                return View();
            }
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]BookDTO book)
        {
            try
            {
                 _cmsApiClient.ApiBooksPost(new External.Api.Models.BookDTO(title: book.Title, author: book.Author));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }       

        // GET: Book/Edit/
        public async Task<ActionResult> Edit(int id)
        {
            var book = await _cmsApiClient.ApiBooksByIdGetAsync(id);
            return View(new BookDTO
            {
                Author = book.Author,
                Title = book.Title,
                Id = book.Id.Value
            });
     
        }

        // POST: Book/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm]BookDTO book)
        {
            try
            {
                _cmsApiClient.ApiBooksPut(new External.Api.Models.BookDTO(book.Id, book.Title,  book.Author));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        [HttpGet]
        public ActionResult Delete([FromRoute]int id)
        {
            try
            {
                _cmsApiClient.ApiBooksByIdDelete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}