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
        private readonly IChatHistoryListSingleton _chatHistoryListSingleton;
        public ChatHub(IChatHistoryListSingleton chatHistoryListSingleton)
        {
            _chatHistoryListSingleton = chatHistoryListSingleton;
        }
        public async Task SendMessage(string user, string message)
        {
            _chatHistoryListSingleton.AddMessage(new Message(user, message));
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Message[] GetHistory()
        {
           return _chatHistoryListSingleton.GetAllMessages().ToArray();
        }

    }
}
