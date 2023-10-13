namespace Assets.Script.Locale
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Text { get; set; }
        public float Delay { get; set; }

        public Message(MessageType type, string text, float delay)
        {
            Type = type;
            Text = text;
            Delay = delay;
        }

        public Message(MessageType type, string text) : this(type, text, 0) { }

        public Message(string text) : this(MessageType.System, text, 0) { }
    }
}
