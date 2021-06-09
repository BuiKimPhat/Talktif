using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Service;

namespace Talktif.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private IUserService _userService;
        private IAdminService _adminService;

        public AdminController(
            ILogger<AdminController> logger, 
            IUserService userService, 
            IAdminService adminService)
        {
            _logger = logger;
            _userService = userService;
            _adminService = adminService;
        }
        public IActionResult Home()
        {
            if (IsAdmin() != true) return NotFound();
            return View(_adminService.GetStatisticData(ReadCookie()));
        }
        public IActionResult Users(string PageNum)
        {
            if (IsAdmin() != true) return NotFound();
            long first = 8, last = 0;
            if(String.IsNullOrEmpty(PageNum) == false)
            {
                last = first * (Int64.Parse(PageNum) -1 );
                first = ( first*(Int64.Parse(PageNum)) > _adminService.GetNumberofUser(ReadCookie()) ) ? _adminService.GetNumberofUser(ReadCookie()) : first*(Int64.Parse(PageNum));
            }
            List<user> users = new List<user>();
            users = _adminService.GetUser(first, last, ReadCookie());
            ViewBag.Users = users;
            ViewBag.NumberofUser = _adminService.GetNumberofUser(ReadCookie());
            return View();
        }
        public IActionResult ReportUser()
        {
            if (IsAdmin() != true) return NotFound();
            return View();
        }
        public IActionResult Setting()
        {
            if (IsAdmin() != true) return NotFound();
            return View();
        }
        //Cookie Service
        private bool IsAdmin()
        {
            string key = "user";
            string cookievalue = Request.Cookies[key];
            Cookie_Data a = JsonConvert.DeserializeObject<Cookie_Data>(cookievalue);
            return a.IsAdmin;
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
        //Cookie Service
    }
}