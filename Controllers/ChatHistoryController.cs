﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRChatServer.Singletons;

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
        public JsonResult GetChatHistory()
        {

            var jsonChatHistory = new JsonResult(chatListSingleton.GetAllMessages());
            return jsonChatHistory;
        }
    }
}