using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcBookLend.Helper;
using MvcBookLend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvcBookLend.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<Controller> _logger;
        private readonly BooklprjtContext _context;


        public UserController(ILogger<HomeController> logger, BooklprjtContext context)
        {
            _logger = logger;
            _context = context;
        }
        bookAPI _api = new bookAPI();

        public async Task<IActionResult> Index()
        {
            List<UserTable> user = new List<UserTable>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/UserTables");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<UserTable>>(res);
            }


            return View(user);
        }
        public ActionResult Create()
        {
            ViewBag.category = new SelectList(_context.Categoytbls, "Category", "Category");
            return View();

        }
        public ActionResult Welcome()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(UserTable user)
        {
            var users = new UserTable();
            var email = users.Email;
            var rtdt = users.Returndate;
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/UserTables", content).Result;
            ViewBag.category = new SelectList(_context.Categoytbls, "Category", "Category");
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        
        [HttpGet]

        public JsonResult Getbook(string Cname)
        {
            var book = _context.Booktbls.Where(e => e.Cname == Cname);
            return Json(new SelectList(book, "BId", "Bookname"));
        }
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient cli = _api.Initial();
            HttpResponseMessage response = cli.DeleteAsync("api/UserTables/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }
    }
}

