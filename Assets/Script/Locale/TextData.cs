namespace Assets.Script.Locale
{
    public class TextData
    {
        public TextType Type { get; set; }
        public string Text { get; set; }
        public float Delay { get; set; }

        public TextData(TextType type, string text, float delay)
        {
            Type = type;
            Text = text;
            Delay = delay;
        }

        public TextData(TextType type, float delay, string text) : this(type, text, delay) { }

        public TextData(TextType type, string text) : this(type, text, 0) { }

        public TextData(string text, float delay) : this(TextType.System, text, delay) { }

        public TextData(float delay, string text) : this(TextType.System, text, delay) { }

        public TextData(string text) : this(TextType.System, text, 0) { }
    }

    public class ItemData
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ItemData(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
