using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Talktif.Models;
using Talktif.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Talktif.Service;
using System;

namespace Talktif.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Home()
        {
            var result = _userService.Get_User_Infor(ReadCookie());
            string a = result.Content.ReadAsStringAsync().Result;
            User_Infor user = JsonConvert.DeserializeObject<User_Infor>(a);
            return View(user);
        }
        public IActionResult History()
        {
            var result = _userService.Get_User_Infor(ReadCookie());
            string a = result.Content.ReadAsStringAsync().Result;
            User_Infor user = JsonConvert.DeserializeObject<User_Infor>(a);
            return View(user);
        }
        public IActionResult Logout()
        {
            RemoveCookie();
            return RedirectToAction("Index","Login");
        }
        public IActionResult Setting()
        {
            var result = _userService.Get_User_Infor(ReadCookie());
            string a = result.Content.ReadAsStringAsync().Result;
            User_Infor user = JsonConvert.DeserializeObject<User_Infor>(a);
            ViewBag.Data = user;
            ViewBag.Cities = _userService.GetCity();
            return View();
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
        private void RemoveCookie()
        {
            string key = "user";
            string value = string.Empty;
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Append(key, value, option);
            if(CheckCookie() == true)
            {
                Console.WriteLine("Error : Can't remove cookie");
            }
        }
        private bool CheckCookie()
        {
            string key = "user";
            string cookievalue = Request.Cookies[key];
            if(String.IsNullOrEmpty(cookievalue))
            return false;
            else return true;
        }
        //Cookie Service
    }
}