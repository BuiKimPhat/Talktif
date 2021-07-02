using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Talktif.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;
        public ChatController(
            ILogger<ChatController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index() 
        {
            return View("ChatSecret");
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
        public IActionResult Chat() 
        {
            return View("Chating");
        }
    }
}