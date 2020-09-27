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
        [HttpGet]
        public JsonResult GetChatHistory()
        {

            var jsonChatHistory = new JsonResult(chatListSingleton.GetAllMessages());
            return jsonChatHistory;
        }

        //POST api/chatcontroller
        [HttpPost]
        public ActionResult PostChatMessage(Message message)
        {
            {
                if (string.IsNullOrEmpty(message.UserName))
                {
                    return BadRequest("Needs a name mate");
                }
                if (string.IsNullOrEmpty(message.MessageText)) { return BadRequest("Add a message please"); }
                chatListSingleton.AddMessage(message);
                return new OkObjectResult("Message Added");
            }
        }
    }
}