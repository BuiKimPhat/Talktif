using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<IActionResult> Home()
        {
            if (_userService.IsAdmin(Request) != true) return NotFound();
            return View( await _adminService.GetStatisticData(Request,Response));
        }
        public async  Task<IActionResult> Users(string PageNum)
        {
            if (_userService.IsAdmin(Request) != true) return NotFound();

            long first = 8, last = 0;
            long NumberofUser = await _adminService.GetNumberofUser(Request,Response);

            if (String.IsNullOrEmpty(PageNum) == false)
            {
                last = first * (Int64.Parse(PageNum) - 1);
                first = (first * (Int64.Parse(PageNum)) > NumberofUser) ? NumberofUser : first * (Int64.Parse(PageNum));
                if (first < last) return NotFound();
            }
            first = (NumberofUser < first) ? NumberofUser : first;
            List<user> users = new List<user>();
            users = await _adminService.GetAllUser(Request, Response, first, last);

            ViewBag.Users = users;
            ViewBag.NumberofUser = NumberofUser;
            return View();
        }
        public async Task<IActionResult> ReportUser(string PageNum)
        {
            if (_userService.IsAdmin(Request) != true) return NotFound();

            long first = 8, last = 0;
            long NumberofReport =await _adminService.GetNumberofReport(Request,Response);

            if (String.IsNullOrEmpty(PageNum) == false)
            {
                last = first * (Int64.Parse(PageNum) - 1);
                first = (first * (Int64.Parse(PageNum)) > NumberofReport) ? NumberofReport : first * (Int64.Parse(PageNum));
                if (first < last) return NotFound();
            }
            first = (NumberofReport > first) ? first : NumberofReport;
            List<Report_Infor> reports = new List<Report_Infor>();
            reports =await _adminService.GetAllReport(Request, Response, first, last);

            ViewBag.Reports = reports;
            ViewBag.NumberofReport = NumberofReport;
            return View();
        }
        public async Task<IActionResult> Setting()
        {
            if( _userService.IsAdmin(Request) != true) return NotFound();
            User_Infor user = await _userService.Get_User_Infor(Request, Response);
            ViewBag.Data = user;
            ViewBag.Cities =await _userService.GetCity();
            return View("AdminSetting");
        }
    }
}