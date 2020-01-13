using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;

using Pawel.Cms.Common.DTOs;
using Pawel.Cms.External.Api;
using WK.Cms.Web.Models;

namespace Pawel.Cms.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly CmsApiClient _cmsApiClient;

        public HomeController(CmsApiClient cmsApiClient)
        {
            _cmsApiClient = cmsApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact([FromForm]EmailDTO model)
        {
            //var response = await _cmsApiClient
            //    .ApiBooksPostWithHttpMessagesAsync(
            //    new External.Api.Models.BookDTO(title: book.Title, author: book.Author));
        
            

            return View();
        }


        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm]BookDTO book)
        {
            var response = await _cmsApiClient.ApiBooksPostWithHttpMessagesAsync(new External.Api.Models.BookDTO(title:book.Title, author:book.Author));
            var status = response.Response.StatusCode;

            ViewData["Message"] = $"Zapisano pomyślnie:{status}";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]int id)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
