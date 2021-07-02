using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Data;
using Talktif.Repository;

namespace Talktif.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserFavRepository _repository;

        public ChatController(ILogger<HomeController> logger, IUserFavRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Friends(int? id)
        {
            // Get user info and pre-setup
            User_Infor usr = UserRepo.Instance.data;
            if (usr == null)
            {
                return RedirectToAction("Index", "Login");
            };

            FriendsViewModel vm = new FriendsViewModel
            {
                UserID = usr.id,
                UserToken = usr.token,
                RoomID = id != null ? (int)id : 0
            };

            // Fetch all chat rooms
            var chatroomResult = ChatRepo.Instance.FetchAllChatRoom(usr.id);
            string crstring = chatroomResult.Content.ReadAsStringAsync().Result;
            if (chatroomResult.IsSuccessStatusCode)
            {
                vm.RoomList = JsonConvert.DeserializeObject<List<Room>>(crstring);
            }

            // Fetch all messages
            if (vm.RoomID > 0)
            {
                FetchMessageRequest req = new FetchMessageRequest
                {
                    RoomId = vm.RoomID,
                    Top = 20
                };
                var messagesResult = ChatRepo.Instance.FetchMessage(req);
                string mrstring = messagesResult.Content.ReadAsStringAsync().Result;
                if (messagesResult.IsSuccessStatusCode)
                {
                    vm.Messages = JsonConvert.DeserializeObject<List<Message>>(mrstring).OrderBy(m => m.sentAt).ToList();
                }
            }
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string a = "";
            a +="city :" + form["format"].ToString() + ", Hobbie :";
            if(form["Sport"] == "on") a+= " " + "Sport";
            if(form["Travel"] == "on") a+= ", " + "Travel";
            if(form["Camping"] == "on") a+= ", " + "Camping";
            if(form["Jogging"] == "on") a+= ", " + "Jogging";
            if(form["Alone"] == "on") a+= ", " + "Alone";
            if(form["Talking"] == "on") a+= ", " + "Talking";
            if(form["Swimming"] == "on") a+= ", " + "Swimming";
            if(form["Learning"] == "on") a+= ", " + "Learning";
            if(form["Singing"] == "on") a+= ", " + "Singing";
            ViewBag.Infor = a;
            return View();
        }
    }
}
