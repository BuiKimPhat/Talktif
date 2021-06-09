using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Service;

namespace Talktif.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if( ReadCookie() == null )
            {
                return RedirectToAction("Index","Login");
            }
            if((ReadCookie()).IsAdmin == false) return RedirectToAction("Home","User");
            else return RedirectToAction("Home","Admin");
        }

        //Cookie Service
        private Cookie_Data ReadCookie()
        {
            string key = "user";
            string cookievalue = Request.Cookies[key];
            if(String.IsNullOrEmpty(cookievalue))
            return null;
            else
            {
                Cookie_Data a = new Cookie_Data();
                a = JsonConvert.DeserializeObject<Cookie_Data>(cookievalue);
                return a;
            }
        }
        //Cookie Service

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
