using System;
using Microsoft.AspNetCore.Http;
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
        private IChatService _chatService;
        public UserController(ILogger<UserController> logger, IUserService userService, IChatService chatService)
        {
            _logger = logger;
            _userService = userService;
            _chatService = chatService;
        }
        public IActionResult Home()
        {
            ViewBag.Cities = _userService.GetCity();
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
        [HttpPost]
        public IActionResult Setting(IFormCollection form)
        {
            string name = form["name"].ToString();
            string email = form["email"].ToString();
            string pass = form["password"].ToString();
            string newpass = form["newpassword"].ToString();
            string confirmpass = form["confirmpassword"].ToString();
            bool gender = (form["Gender"].ToString() == "Male") ? true : false;
            int CityId = Convert.ToInt32(form["format"].ToString());
            Console.WriteLine(pass);
            Console.WriteLine(newpass);
            Console.WriteLine(confirmpass);
            return RedirectToAction("Home");
        }
    }
}