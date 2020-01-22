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
        private readonly IChatListSingleton _chatDictionarySingleton;
        public ChatHub(IChatListSingleton chatDictionarySingleton)
        {
            _chatDictionarySingleton = chatDictionarySingleton;
        }
        public async Task SendMessage(string user, string message)
        {
            _chatDictionarySingleton.AddMessage(new Message(user, message));
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Message[] GetHistory()
        {
           
           return _chatDictionarySingleton.GetAllMessages().ToArray();
        }

    }
}
