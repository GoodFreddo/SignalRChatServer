namespace SignalRChatServer.Singletons
{
    public class Message {
        public Message(string UserName, string MessageText)
        {
            this.UserName = UserName;
            this.MessageText = MessageText;
        }

        public string UserName { get; }
        public string MessageText { get; }
    }
}
