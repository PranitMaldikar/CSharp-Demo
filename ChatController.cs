using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ChatbotApp.Models;

namespace ChatbotApp.Controllers
{
    public class ChatController : Controller
    {
        // In-memory chat messages for demonstration
        private static List<ChatMessage> chatMessages = new List<ChatMessage>();

        // GET: Chat
        [Authorize]
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(chatMessages.Where(m => m.UserId == (int)Session["UserId"]).ToList());
        }

        // POST: Chat/SendMessage
        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var chatMessage = new ChatMessage
            {
                Id = chatMessages.Count > 0 ? chatMessages.Max(m => m.Id) + 1 : 1,
                UserId = (int)Session["UserId"],
                Message = message,
                Response = "Echo: " + message, // Simple echo bot response
                Timestamp = DateTime.Now
            };
            chatMessages.Add(chatMessage);

            return RedirectToAction("Index");
        }
    }
}
