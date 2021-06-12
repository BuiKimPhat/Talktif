using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
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
            return View(_adminService.GetStatisticData((ReadCookie()).token));
        }
        public IActionResult Users(string PageNum)
        {
            if (IsAdmin() != true) return NotFound();

            long first = 8, last = 0;
            Cookie_Data cookie_Data = ReadCookie();
            long NumberofUser = _adminService.GetNumberofUser(cookie_Data.token);
            
            if (String.IsNullOrEmpty(PageNum) == false)
            {
                last = first * (Int64.Parse(PageNum) - 1);
                first = (first * (Int64.Parse(PageNum)) > NumberofUser) ? NumberofUser : first * (Int64.Parse(PageNum));
                if(first < last) return NotFound();
            }
            first = (NumberofUser < first ) ? NumberofUser : first ;
            List<user> users = new List<user>();
            var result = _adminService.GetUser(first, last, cookie_Data.token);
            string a = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = _adminService.GetNameCity(Int32.Parse(users[i].cityID));
                }
            }
            else
            {
                RefreshToken(cookie_Data);
                cookie_Data = ReadCookie();
                result = _adminService.GetUser(first, last, cookie_Data.token);
                a = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = _adminService.GetNameCity(Int32.Parse(users[i].cityID));
                }
            }

            ViewBag.Users = users;
            ViewBag.NumberofUser = NumberofUser;
            return View();
        }
        public IActionResult ReportUser(string PageNum)
        {
            if (IsAdmin() != true) return NotFound();

            long first = 8, last = 0;
            Cookie_Data cookie_Data = ReadCookie();
            long NumberofReport = _adminService.GetNumberofReport(cookie_Data.token);

            if (String.IsNullOrEmpty(PageNum) == false)
            {
                last = first * (Int64.Parse(PageNum) - 1);
                first = (first * (Int64.Parse(PageNum)) > NumberofReport) ? NumberofReport : first * (Int64.Parse(PageNum));
                if(first < last) return NotFound();
            }
            first = (NumberofReport > first ) ? first : NumberofReport;
            List<Report_Infor> reports = new List<Report_Infor>();
            var result = _adminService.GetReport(first, last, cookie_Data.token);
            string a = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(a);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
                reports = JsonConvert.DeserializeObject<List<Report_Infor>>(a);
            }
            else
            {
                Console.WriteLine("Toang");
                RefreshToken(cookie_Data);
                cookie_Data = ReadCookie();
                result = _adminService.GetReport(first, last, cookie_Data.token);
                a = result.Content.ReadAsStringAsync().Result;
                reports = JsonConvert.DeserializeObject<List<Report_Infor>>(a);
            }

            ViewBag.Reports = reports;
            ViewBag.NumberofReport = NumberofReport;
            return View();
        }
        public IActionResult Setting()
        {
            if (IsAdmin() != true) return NotFound();
            return View();
        }

        private void RefreshToken(Cookie_Data cookie)
        {
            cookie.token = _userService.RefreshToken(cookie.email, cookie.token);
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
            if (CheckCookie() == false)
            {
                Console.WriteLine("Error : Can't update cookie");
            }
        }
        private bool CheckCookie()
        {
            string key = "user";
            string cookievalue = Request.Cookies[key];
            if (String.IsNullOrEmpty(cookievalue))
                return false;
            else return true;
        }
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
            if (String.IsNullOrEmpty(cookievalue))
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