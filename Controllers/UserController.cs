using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Talktif.Models;
using Talktif.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Talktif.Service;

namespace Talktif.Controllers
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
            return View(UserRepo.Instance.data);
        }
        public IActionResult History()
        {
            return View(UserRepo.Instance.data);
        }
        public IActionResult Logout()
        {
            UserService.Instance.RemoveData();
            return RedirectToAction("Index","Login");
        }
        public IActionResult Setting()
        {
            ViewBag.Data = UserRepo.Instance.data;
            ViewBag.Cities = AdminRepo.Cities;
            return View();
        }
    }
}