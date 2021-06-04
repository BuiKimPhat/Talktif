using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Repository;

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
            if (UserRepo.Instance.data.isAdmin != true) return NotFound();
            AdminRepo.Instance.data = GetData();
            return View(AdminRepo.Instance.data);
        }
        public IActionResult Users()
        {
            if (UserRepo.Instance.data.isAdmin != true) return NotFound();
            List<user> users = new List<user>();
            try
            {
                HttpResponseMessage result = AdminRepo.Instance.GetAllUser(8, 0);
                string a = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = AdminRepo.Instance.GetNameCity(Int32.Parse(users[i].cityID));
                }
                return View(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                UserRepo.Instance.data.token = RefreshToken();

                HttpResponseMessage result = AdminRepo.Instance.GetAllUser(8, 0);
                string a = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = AdminRepo.Instance.GetNameCity(Int32.Parse(users[i].cityID));
                }
                return View(users);
            }
        }
        public IActionResult ReportUser()
        {
            if (UserRepo.Instance.data.isAdmin != true) return NotFound();
            return View();
        }
        public IActionResult Setting()
        {
            if (UserRepo.Instance.data.isAdmin != true) return NotFound();
            return View();
        }
        private Statistic GetData()
        {
            Statistic stat = new Statistic();
            try
            {
                var result = AdminRepo.Instance.Statistic();
                var statisticsResult = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Statistic>(statisticsResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
                UserRepo.Instance.data.token = RefreshToken();

                var result = AdminRepo.Instance.Statistic();
                var statisticsResult = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Statistic>(statisticsResult);
            }
        }
        private string RefreshToken()
        {
            RefreshTokenRequest r = new RefreshTokenRequest() { Email = UserRepo.Instance.data.email };
            var refreshToken = UserRepo.Instance.RefreshToken(r);
            var result = refreshToken.Content.ReadAsStringAsync().Result;
            Token t = JsonConvert.DeserializeObject<Token>(result);
            return t.token;
        }
    }
}