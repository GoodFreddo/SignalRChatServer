using System.Collections.Generic;

namespace SignalRChatServer.Singletons
{
    public interface IChatHistoryListSingleton
    {
        void AddMessage(Message message);
        List<Message> GetAllMessages();
    }
    public class ChatHistoryListSingleton : IChatHistoryListSingleton
    {
        List<Message> chatHistory = new List<Message>();

        public void AddMessage(Message message)
        {
            chatHistory.Add(message);
        }

        public List<Message> GetAllMessages()
        {
            return chatHistory;
        }
    }
}
