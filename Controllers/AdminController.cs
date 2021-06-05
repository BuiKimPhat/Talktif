using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Talktif.Models;
using Talktif.Service;

namespace Talktif.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
        public IActionResult Home()
        {
            if (UserService.Instance.IsAdmin() != true) return NotFound();
            return View(AdminService.Instance.GetStatisticData());
        }
        public IActionResult Users(string PageNum)
        {
            if (UserService.Instance.IsAdmin() != true) return NotFound();
            long first = 8, last = 0;
            if(String.IsNullOrEmpty(PageNum) == false)
            {
                last = first * (Int64.Parse(PageNum) -1 );
                first = ( first*(Int64.Parse(PageNum)) > AdminService.Instance.GetNumberofUser() ) ? AdminService.Instance.GetNumberofUser() : first*(Int64.Parse(PageNum));
            }
            List<user> users = new List<user>();
            users = AdminService.Instance.GetUser(first, last);
            return View(users);
        }
        public IActionResult ReportUser()
        {
            if (UserService.Instance.IsAdmin() != true) return NotFound();
            return View();
        }
        public IActionResult Setting()
        {
            if (UserService.Instance.IsAdmin() != true) return NotFound();
            return View();
        }
    }
}