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
    }
}