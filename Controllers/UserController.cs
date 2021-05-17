using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models;
using Program.Repository;
using Microsoft.AspNetCore.Http;

namespace Program.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        public IActionResult Home()
        {
            //if(Repo.Instance.data.isAdmin == true) return NotFound();
            return View(Repo.Instance.data);
        }
        [HttpPost]
        public IActionResult Home(IFormCollection formCollection)
        {
            Repo.Instance.data = null;
            return RedirectToAction("Login","Login");
        }
    }
}