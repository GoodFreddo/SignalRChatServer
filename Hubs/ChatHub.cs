using Microsoft.AspNetCore.SignalR;
using SignalRChatServer.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatServer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatDictionarySingleton _chatDictionarySingleton;
        public ChatHub(IChatDictionarySingleton chatDictionarySingleton) {
            _chatDictionarySingleton = chatDictionarySingleton;
        }
        public async Task SendMessage(string user, string message)
        {
            _chatDictionarySingleton.AddMessage(user,message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task GetHistory() {
            await Clients.Caller.SendAsync("RecieveHistory", _chatDictionarySingleton.GetAllMessages().ToString());
        }
        
    }
}
