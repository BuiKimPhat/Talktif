using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Talktif.Models;
using Newtonsoft.Json;
using Talktif.Service;

namespace Talktif.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private IUserService _userService;

        public LoginController(ILogger<LoginController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index(MessageRequest m)
        {
            ViewBag.Message = m;
            ViewBag.Cities = _userService.GetCity();
            return View();
        }
        [HttpPost]
        public IActionResult Sign_In(IFormCollection form)
        {
            LoginRequest lr = new LoginRequest() { Email = form["Email"].ToString(), Password = form["Password"].ToString(), Device = (System.Environment.MachineName).ToString() };
            var loginResult = _userService.Sign_In(lr);
            string a = loginResult.Content.ReadAsStringAsync().Result;
            if (loginResult.IsSuccessStatusCode)
            {
                Console.WriteLine("login success");
                //create cookie
                User_Infor user = JsonConvert.DeserializeObject<User_Infor>(a);
                _userService.CreateCookie(Response, new Cookie_Data() { id = user.id, IsAdmin = user.isAdmin, email = user.email, token = user.token });
                //create cookie
                return RedirectToAction("Index", "Home");
            }
            MessageRequest m = new MessageRequest() { Message = a };
            return RedirectToAction("Index", m);
        }
        [HttpPost]
        public IActionResult Sign_Up(IFormCollection form)
        {
            SignUpRequest sr = new SignUpRequest()
            {
                Name = form["Name"].ToString(),
                Email = form["Email"].ToString(),
                Password = form["Password"].ToString(),
                Gender = (form["Gender"].ToString() == "Male") ? true : false,
                CityId = Convert.ToInt32(form["format"].ToString()),
                Hobbies = "Travel",
                Device = System.Environment.MachineName,
            };
            var signUpResult = _userService.Sign_Up(sr);
            string a = signUpResult.Content.ReadAsStringAsync().Result;
            if (signUpResult.IsSuccessStatusCode)
            {
                //create cookie
                User_Infor user = JsonConvert.DeserializeObject<User_Infor>(a);
                _userService.CreateCookie(Response, new Cookie_Data() { id = user.id, IsAdmin = user.isAdmin, email = user.email, token = user.token });
                //create cookie
                return RedirectToAction("Index", "Home");
            }
            MessageRequest m = new MessageRequest() { Message = a };
            return RedirectToAction("Index", m);
        }
        public IActionResult ForgotPass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPass(IFormCollection form)
        {
            var resetPassResult = _userService.ResetPass(form["Email"].ToString());
            string a = resetPassResult.Content.ReadAsStringAsync().Result;
            Console.WriteLine(a);
            if (resetPassResult.IsSuccessStatusCode)
            {
                //sent a to new page
                return RedirectToAction("ResetPasswordEmail");
            }//else sent to old page and the message
            return RedirectToAction("Index", new MessageRequest() { Message = a });
        }
        public IActionResult ResetPasswordEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPasswordEmail(IFormCollection form)
        {
            return NotFound();
        }
    }
}