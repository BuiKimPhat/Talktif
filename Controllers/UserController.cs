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
         public IActionResult ChatSecret()
        {
            // User_Infor user = Get_User_Infor();
            return View();
        }
        public IActionResult Home()
        {
            User_Infor user = Get_User_Infor();
            return View(user);
        }
        public IActionResult History()
        {
            User_Infor user = Get_User_Infor();
            return View(user);
        }
        public IActionResult Logout()
        {
            RemoveCookie();
            return RedirectToAction("Index","Login");
        }
        public IActionResult Setting()
        {
            User_Infor user = Get_User_Infor();
            ViewBag.Data = user;
            ViewBag.Cities = _userService.GetCity();
            return View();
        }
        private User_Infor Get_User_Infor()
        {
            var cookie = ReadCookie();
            var result = _userService.Get_User_Infor(cookie);
            if(result.IsSuccessStatusCode)
            {
                string a = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User_Infor>(a);
            }else
            {
                RefreshToken(cookie);
                cookie = ReadCookie();
                result = _userService.Get_User_Infor(cookie);
                string a = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User_Infor>(a);
            }
        }
        private void RefreshToken(Cookie_Data cookie)
        {
            cookie.token = _userService.RefreshToken(cookie.email,cookie.token);
            UpdateCookie(cookie);

        }
        //Cookie Service
        private void UpdateCookie(Cookie_Data cookie)
        {
            string key = "user";
            string value = JsonConvert.SerializeObject(cookie);
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Append(key, value, option);
            if(CheckCookie() == false)
            {
                Console.WriteLine("Error : Can't update cookie");
            } 
        }
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