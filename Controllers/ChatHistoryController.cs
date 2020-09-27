using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRChatServer.Singletons;
using System;

namespace SignalRChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHistoryController : ControllerBase
    {
        IChatHistoryListSingleton chatListSingleton;
        public ChatHistoryController(IChatHistoryListSingleton chatListSingleton)
        {
            this.chatListSingleton = chatListSingleton;
        }
        //GET api/chatcontroller
        [HttpGet]
        public JsonResult GetChatHistory()
        {

            var jsonChatHistory = new JsonResult(chatListSingleton.GetAllMessages());
            return jsonChatHistory;
        }

        //POST api/chatcontroller
        [HttpPost]
        public JsonResult PostChatMessage(Message message)
        {
            {
                if (string.IsNullOrEmpty(message.UserName)) { return new JsonResult("Needs a name mate."); }
                if (string.IsNullOrEmpty(message.MessageText)) { return new JsonResult("Add a message please"); }
                chatListSingleton.AddMessage(message);
                return new JsonResult("Message Added");
            } 
        }
    }
}