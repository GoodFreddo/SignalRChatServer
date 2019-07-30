using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatServer.Singletons
{
    public interface IChatDictionarySingleton {
        void AddMessage(string username, string message);
        Dictionary<string, string> GetAllMessages();
    }
    public class ChatDictionarySingleton : IChatDictionarySingleton
    {
        Dictionary<string, string> chatHistory = new Dictionary<string, string>() ;

        public void AddMessage(string username, string message)
        {
            chatHistory.Add(username, message);
        }
        public Dictionary<string, string> GetAllMessages()
        {
            return chatHistory;
        }
    }
}
