using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models;
using Program.Repository;

namespace Program.Controllers
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
            if(Repo.Instance.data == null)
            {
                Repo.Instance.data = new User_Infor();
                return RedirectToAction("Login","Login");
            } 
            //return View(Repo.Instance.data);
            if(Repo.Instance.data.isAdmin == false) return RedirectToAction("Home","User");
            else return RedirectToAction("Home","Admin");
        } 
        
        // [HttpGet]
        // [Route("VerifyEmail")]
        // public IActionResult VerifyEmail(int id,string token)
        // {
        //     try{
        //         Console.WriteLine(id+ " "+token);
        //         Repo.Instance.VertifyEmail(id,token);
        //         return RedirectToAction("Login","Login"); 
        //     }catch (Exception e){
        //         Console.WriteLine(e.Message);
        //         return RedirectToAction("Login","Login");
        //     }
        // }

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
