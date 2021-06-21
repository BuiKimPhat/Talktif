using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Talktif.Models;
using Talktif.Service;

namespace Talktif.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Home()
        {
            User_Infor user = _userService.Get_User_Infor(Request, Response);
            ViewBag.nameUser = user.name;
            ViewBag.nameCity = _userService.GetNameCity(user.cityId);
            return View();
        }
        public IActionResult Logout()
        {
            _userService.RemoveCookie(Response);
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Setting()
        {
            User_Infor user = _userService.Get_User_Infor(Request, Response);
            ViewBag.Data = user;
            ViewBag.Cities = _userService.GetCity();
            return View();
        }
    }
}