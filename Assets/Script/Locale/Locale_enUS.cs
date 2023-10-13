using System.Collections.Generic;

namespace Assets.Script.Locale
{
    public static class Locale_enUS
    {
        public static readonly List<Message> Messages = new List<Message>()
        {
            // 0 - 2
            // Background
            new Message("In the year 2068, Au Revoir Ltd. initiated its expansion by introducing to the world the most groundbreaking technological innovation ever witnessed. The novelty was a revolutionary chip capable of storing an individual's complete consciousness. This advancement allowed one's consciousness to persist even after the death of the physical body, waiting for the opportunity to inhabit a new \"vessel.\" The Au Revoir brand quickly rose to prominence, expanding its operations into other sectors, ultimately becoming the largest corporation on the entire planet."),
            new Message("With this great innovation, the powerful elite began to live eternally, transferring their consciousness to new vessels whenever their bodies perished. To ensure the continuity of these immortal existences, a new profession emerged. The so-called Sentinels are responsible for the safe retrieval of chips from all those who secured eternal life through Au Revoir Ltd., ensuring the digital continuity of their existence."),
            new Message("Although Au Revoir's research advancements have successfully improved the generation of artificial organs, ensuring safety and precision, the creation of complete \"vessels\" remains an unsolved challenge. The use of these chips in third parties is strictly forbidden, leaving a society marked and constrained by ethical boundaries and the fear of a burgeoning body replacement market. The balance between the quest for digital immortality and technological limitations continues to shape the world to this day."),

            // 3 - 12
            // Wake-up Call
            new Message(MessageType.Boss, "Awake, Sentinel?"),
            new Message(MessageType.Player, "Yes, I am. Did something happen?"),
            new Message(MessageType.Boss, "I need you for another job! Come to the office as soon as possible!"),
            new Message(MessageType.Player, "You can count on me!"),
            new Message(MessageType.Player, "You can count on me, boss! I just need to get ready, and I'll be there in a few minutes!"),
            new Message(MessageType.Boss, "Don't be late again, okay?"),
            new Message(MessageType.Player, "I'm always ready!"),
            new Message(MessageType.Player, "I'm always ready! You can rely on me!"),
            new Message(MessageType.Boss, "Don't lie to me. We both know you haven't been a punctuality role model. I'll be waiting for you!"),
            new Message(MessageType.PlayerThinking, "I better not be late, but I can't leave without grabbing my things. That would be even worse."),

            // 13 - 14
            // Voicemail
            new Message(MessageType.ExWife, "Hey, Tristan, what's happening over there at your job? I went to get Julie's medications, and they were denied! This Au Revoir is just making me look bad! I don't know why I married you... can't even ensure your own daughter's health."),
            new Message(MessageType.PlayerThinking, "She thinks my job is easy. Selfish..."),

            // 15 - 16
            // Thinking about daughter
            new Message(MessageType.PlayerThinking, "I miss my little Julie. I hope Vivian is taking good care of her."),
            new Message(MessageType.PlayerThinking, "Another memory of my beloved daughter."),
        };
    }
}
