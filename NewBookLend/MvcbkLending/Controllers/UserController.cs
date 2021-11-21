using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcbkLending.Helper;
using MvcbkLending.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvcbkLending.Controllers
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
        public ActionResult Welcome()
        {
            return View();

        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.category = new SelectList(_context.Categoytbls, "Category", "Category");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(UserTable user)
        {
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
        public ActionResult condition()
        {
            var user = _context.UserTables;
            foreach(UserTable u in user)
            {
                var email = u.Email;
            }
            return View();
        }
        
        [HttpGet]
        public JsonResult Getbook(string Cname)
        {
            var book = _context.Booktbls.Where(e => e.Cname == Cname);
            return Json(new SelectList(book, "Bookname", "Bookname"));
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
        [HttpGet]
        public JsonResult checkUser(string mail)
        {
            var ckemail = _context.UserTables.Where(e => e.Email == mail).SingleOrDefault();
            if(ckemail!= null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        [HttpGet]
        public JsonResult getuserinfo(string mail)
        {
            List<UserTable> users = _context.UserTables.Where(e=>e.Email==mail).ToList<UserTable>();
            return Json(new { data = users }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}

