using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mvc.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BooklprjtContext _context;


        public HomeController(ILogger<HomeController> logger,BooklprjtContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var category = _context.Categoytbls.ToList();
            return View(category);
        }

        public IActionResult BookIndex()
        {
            var booktbls = _context.Booktbls.ToList();
            return View(booktbls);
        }

        public IActionResult cascadecategory()
        {
            ViewBag.category = new SelectList(_context.Categoytbls, "Id", "Category");
            return View();
        }

        public JsonResult loadbook(int Id)
        {
            var books = _context.Booktbls.Where(e => e.Cid == Id).ToList();
            return Json(new SelectList(books, "bId", "Bookname"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
