using System.Collections.Generic;

namespace Assets.Script.Locale
{
    public static class Locale_enUS
    {
        public static readonly Dictionary<TextGroup, List<TextData>> Texts = new()
        {
            {
                TextGroup.Menu,
                new List<TextData>()
                {
                    new TextData("> Play"),
                    new TextData("> Quit"),
                    new TextData("> Continue"),
                    new TextData("Volume"),
                }
            },
            {
                TextGroup.Intro,
                new List<TextData>()
                {
                    new TextData("In the year 2068, Au Revoir Ltd unleashed its expansion by introducing to the world the greatest technological innovation ever seen. The novelty was a revolutionary chip capable of storing a person's complete consciousness. This advancement allowed one's consciousness to persist even after the body's death, waiting for the opportunity to inhabit a new 'sleeve.' The Au Revoir brand quickly ascended, expanding its operations into other domains and becoming the largest corporation on the planet."),
                    new TextData("With the great innovation, the powerful began to live forever, switching their sleeves whenever their bodies died. To ensure the continued existence of these individuals, a new profession emerged. The so-called Sentinels are responsible for the safe retrieval of the chips of all those assured of eternal life by Au Revoir Ltd, guaranteeing the continuity of digital existence."),
                    new TextData("While Au Revoir's research advances have successfully improved the generation of artificial organs, ensuring safety and precision, the creation of 'sleeves' remains an unsolved challenge. The use of chips in third parties is strictly prohibited, leaving a society marked and limited by ethical boundaries and the fear of the emergence of a body replacement market. The balance between the pursuit of digital immortality and technological limitations continues to shape the world today."),
                }
            },
            // Scene 1
            {
                TextGroup.DialogWakeUpCall,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Awake, Sentinel?"),
                    new TextData(TextType.Player, "Yes, I am. Did something happen?"),
                    new TextData(TextType.Boss, "I need you for another job. Come to the office as soon as possible."),
                    new TextData(TextType.Player, "Sure, boss."),
                    new TextData(TextType.Player, "Sure, boss. I just need to get ready, and I'll be there in a few minutes."),
                    new TextData(TextType.Boss, "Okay, don't be late again."),
                    new TextData(TextType.Player, "I'm always ready."),
                    new TextData(TextType.Player, "I'm always ready. You can count on me!"),
                    new TextData(TextType.Boss, "Don't try to be cute with me. The job pays well, don't be late again. I'm waiting for you."),
                    new TextData(TextType.PlayerThinking, "I better not be late. Where are my keys?"),
                }
            },
            {
                TextGroup.ExWifeVoicemail,
                new List<TextData>()
                {
                    new TextData(TextType.ExWife, "Hey Tristan, what happened at your work? I went to get Julie's medications, and they were denied!"),
                    new TextData(TextType.ExWife, "This Au Revoir always embarrasses me!"),
                    new TextData(TextType.ExWife, "I don't know why I married you... you can't even ensure your own daughter's health."),
                    new TextData(TextType.PlayerThinking, "She thinks my job is easy..."),
                }
            },
            {
                TextGroup.RememberingDaughter,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "I miss my little Julie. I hope Vivian is taking good care of her."),
                }
            },
            // Scene 2
            {
                TextGroup.TVManualInspect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "I need to change the default TV password."),
                }
            },
            {
                TextGroup.TVManualGrab,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "I'll take this; I have nothing to read on the way."),
                    new TextData(TextType.PlayerThinking, "Wow, my keys were right here."),
                }
            },
            {
                TextGroup.HouseKeys,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "There you are!"),
                }
            },
            {
                TextGroup.TVNews,
                new List<TextData>()
                {
                    new TextData(TextType.NewsAnchor, "...today's latest news"),
                    new TextData(TextType.NewsAnchor, "Residents near the Disconnected District complain of a foul odor in the area"),
                    new TextData(TextType.NewsAnchor, "A class-action lawsuit has been initiated against the cleaning service provider"),
                    new TextData(TextType.NewsAnchor, "The company reports difficulties due to the lack of signal for the robots operating in the area"),
                    new TextData(TextType.NewsAnchor, "But residents insist and blame the company for the poor quality of service"),
                    new TextData(TextType.NewsAnchor, "Authorities reported system failures around the Disconnected District"),
                    new TextData(TextType.NewsAnchor, "Some devices seem to have been reset to factory defaults"),
                    new TextData(TextType.NewsAnchor, "Security has been reinforced to maintain isolation"),
                    new TextData(TextType.NewsAnchor, "Crime remains high and shows no signs of decreasing"),
                    new TextData(TextType.NewsAnchor, "Community actions by Au Revoir have been put on hold until further notice"),
                    new TextData(TextType.NewsAnchor, "Leaving residents anxious about the absence of the only benefactor who has hope of reclaiming the area"),
                    new TextData(TextType.NewsAnchor, "Meanwhile, Au Revoir's stocks continue to rise and attract investors..."),
                }
            },
            // Scene 3
            {
                TextGroup.EmployeeOfTheMonth,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "'Allen, Barry - Sentinel of the Month'"),
                    new TextData(TextType.PlayerThinking, "Damn Barry, won again. Just because he gets the job done quickly..."),
                }
            },
            {
                TextGroup.BossPlaque,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "'Béatrice Durand - Supervisor'"),
                }
            },
            {
                TextGroup.BossOfferMisson,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "I'm here boss!"),
                    new TextData(TextType.Boss, "Look who's here! Right on time this time."),
                    new TextData(TextType.Boss, "As you may already suspect, another rich boy has fucked up, and we need to retrieve his chip."),
                    new TextData(TextType.Boss, "The problem is, it happened within the Disconnected District, and we don't have free access to that place."),
                    new TextData(TextType.Boss, "And we can't wait two weeks for authorization."),
                    new TextData(TextType.Boss, "Directives from higher up."),
                    new TextData(TextType.Boss, "So, you'll have to find a way to get in."),
                    new TextData(TextType.Player, "No problem."),
                    new TextData(TextType.Player, "No problem, I'll find a way to get in."),
                    new TextData(TextType.Player, "I don't want to go in there!"),
                    new TextData(TextType.Player, "I don't want to go in there! That place is too dangerous."),
                    new TextData(TextType.Boss, "That's why we can't wait two weeks. By then, the chip will be long gone."),
                    new TextData(TextType.Boss, "That's why I need you to go now. You owe me one!"),
                    new TextData(TextType.Boss, "I thought about calling Barry, but I know you need the cash."),
                    new TextData(TextType.Player, "We had another issue with Julie's medicine. I really need it."),
                    new TextData(TextType.Boss, "So, you know what to do."),
                    new TextData(TextType.Boss, "Try to convince a guard or something."),
                    new TextData(TextType.Boss, "Once you're in, look for a laundry. The chip should be there."),
                    new TextData(TextType.Boss, "Or somewhere close because we're having signal issues in the area."),
                    new TextData(TextType.Boss, "But you find a way to locate it. I'm transferring you the map with the last known location."),
                    new TextData(TextType.Boss, "If you have any questions, just let me know."),
                }
            },
            {
                TextGroup.BossMoreInfo,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "No files? Name or photo?"),
                    new TextData(TextType.Boss, "Confidential, must be someone important."),
                    new TextData(TextType.PlayerThinking, "Important? In the Disconnected District?"),
                    new TextData(TextType.Player, "And how do I get there?"),
                    new TextData(TextType.Boss, "The company car will drop you off at the nearest entrance. The rest is up to you!"),
                    new TextData(TextType.Player, "Alright! I'll be back shortly."),
                }
            },
            // Scene 4
            {
                TextGroup.WallGuard,
                new List<TextData>()
                {
                    new TextData(TextType.Guard, "Step away, citizen! This area is isolated, and no one enters or exits."),
                    new TextData(TextType.Player, "I have permission (bluff)"),
                    new TextData(TextType.Guard, "Funny, I'm notified when the State grants permission."),
                    new TextData(TextType.Player, "Is it very dangerous in there?"),
                    new TextData(TextType.Guard, "The police don't patrol in there, so it's a no man's land."),
                    new TextData(TextType.Player, "What's that elevator behind you for?"),
                    new TextData(TextType.Guard, "It goes to the Disconnected District. Down there where the streets used to be."),
                }
            },
            // Scene 5
            {
                TextGroup.SewersDoorInspect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Sewer service door. Is this the way?"),
                }
            },
            {
                TextGroup.SewersDoorLocked,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "The door is locked. What could the password be?"),
                }
            },
            {
                TextGroup.SewersDoorPanel,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "They haven't changed the default password either."),
                }
            },
            // Scene 6
            {
                TextGroup.Sewers,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "What a smelly place!"),
                }
            },
            {
                TextGroup.StuffedBear,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "My little Julie... I hope I can get the money for her medications."),
                }
            },
            {
                TextGroup.SewersRobot,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Hey, robot!"),
                    new TextData(TextType.Robot, "I, robot?"),
                    new TextData(TextType.Player, "Yes! What are you doing here?"),
                    new TextData(TextType.Robot, "I'm just a cleaning robot."),
                    new TextData(TextType.Player, "Do you know the way out of this place?"),
                    new TextData(TextType.Robot, "I don't know, they don't let me leave here."),
                    new TextData(TextType.Robot, "Do you know how to get out of here?"),
                    new TextData(TextType.Player, "Do you know where is the laundry?"),
                    new TextData(TextType.Robot, "What is a laundry?"),
                    new TextData(TextType.Player, "Never mind..."),
                }
            },
            // Scene 7
            {
                TextGroup.Alley,
                new List<TextData>()
                {
                    new TextData(TextType.Beggar, "Can you spare some change?"),
                }
            },
            {
                TextGroup.DirectionsToLaundry,
                new List<TextData>()
                {
                    new TextData(TextType.Beggar, "I've never seen you around here... Are you here to stir up more trouble?"),
                    new TextData(TextType.Player, "No, I'm looking for a Laundry."),
                    new TextData(TextType.Beggar, "You're right next to it."),
                    new TextData(TextType.Beggar, "I just don't think you'll want to wash your clothes there."),
                    new TextData(TextType.Player, "Thank you."),
                }
            },
            {
                TextGroup.DirectionsToMorgue,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Have you seen anyone carrying a body around here?"),
                    new TextData(TextType.Beggar, "A body? Have you thought about checking the morgue?"),
                    new TextData(TextType.Player, "Good idea! Thank you."),
                    new TextData(TextType.Beggar, "Follow this street, and you'll find what you're looking for."),
                }
            },
            // Scene 8
            {
                TextGroup.LaundryStreet,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "A laundromat... this must be the place."),
                }
            },
            {
                TextGroup.BloodMarks,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "It looks like there was a physical altercation here."),
                    new TextData(TextType.PlayerThinking, "Even with the rain, you can still see traces of blood."),
                    new TextData(TextType.PlayerThinking, "Looks like the body was moved... it's going to be one of those days."),
                }
            },
            // Scene 9
            {
                TextGroup.Laundry,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "This area is very strange. Why would someone die in a laundry?"),
                }
            },
            {
                TextGroup.LaundryBody,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "This isn't the one I'm looking for. It doesn't have a chip."),
                    new TextData(TextType.PlayerThinking, "Another one without a chip. Makes me wonder how someone with access to a chip died here."),
                    new TextData(TextType.PlayerThinking, "Could be this one, since it's the last one. This one only has a weapon; looks like they were a criminal or something."),
                }
            },
            {
                TextGroup.LaundryMachine,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "This machine is empty."),
                }
            },
            {
                TextGroup.LaundryMachine13,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "I think someone left clothes in this machine."),
                }
            },
            {
                TextGroup.LaundryMachine16Inspect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "This one seems locked. And it has a biometric device. Strange..."),
                }
            },
            {
                TextGroup.LaundryMachine16UseFail,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "It doesn't hurt to try with my finger..."),
                    new TextData(TextType.PlayerThinking, "Nothing. Who can open this?"),
                }
            },
            // Scene 10
            {
                TextGroup.ClosedBuildings,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Everything is closed around here. Does anyone live inside?"),
                }
            },
            {
                TextGroup.Homeless,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Hey, you!"),
                    new TextData(TextType.Beggar, "What do you want? I don't want your money."),
                    new TextData(TextType.Player, "Where's the laundry?"),
                    new TextData(TextType.Player, "Can you tell me where the laundry is?"),
                    new TextData(TextType.Beggar, "Oh, you're just another crazy one. Or are you blind? You came from there."),
                    new TextData(TextType.Player, "Where do they take the bodies of the deceased?"),
                    new TextData(TextType.Player, "What happens to those who die around here? Do they take the body somewhere?"),
                    new TextData(TextType.Beggar, "Most of them end up staying where they died, until someone gets bothered."),
                    new TextData(TextType.Beggar, "But when they're on the street, they sometimes take them to the morgue down the street."),
                    new TextData(TextType.Player, "Where can I go to have some fun?"),
                    new TextData(TextType.Player, "I'm looking to have some fun. Is there a nice place to hang out around here?"),
                    new TextData(TextType.Beggar, "I only know that those who know the Mafia have a good time at the club at the end of the street."),
                    new TextData(TextType.Beggar, "But I don't recommend it. A friend of mine went in there once and I never saw him again."),
                    new TextData(TextType.Beggar, "Or maybe it was him who said he was going on a trip... anyway, the risk is yours."),
                    new TextData(TextType.Player, "Thank you."),
                }
            },
            // Scene 11
            // Scene 12
            {
                TextGroup.Morgue,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "There's no one here. It seems to be a self-service system. Didn't expect that in a morgue."),
                }
            },
            {
                TextGroup.MorgueHUD,
                new List<TextData>()
                {
                    new TextData("Location of death:"),
                    new TextData("Cause of death:"),
                }
            },
            {
                TextGroup.MorgueCorpses,
                new List<TextData>()
                {
                    new TextData("Viktor\nSteele"),
                    new TextData("11/07/2068"),
                    new TextData("Neon Eclipse Bar"),
                    new TextData("Poisoning by unknown substance"),

                    new TextData("Marie\nLeClaire"),
                    new TextData("11/10/2068"),
                    new TextData("Renaissance Motel"),
                    new TextData("Concussions throughout the body"),

                    new TextData("Barbie\nPoupée"),
                    new TextData("11/12/2068"),
                    new TextData("Au Revoir Toys"),
                    new TextData("3rd-degree burns from melted plastic"),

                    new TextData("Unknown"),
                    new TextData("11/13/2068"),
                    new TextData("Sewer"),
                    new TextData("Decapitated with erased fingerprints"),

                    new TextData("Sébastien\nBain"),
                    new TextData("11/17/2068"),
                    new TextData("Main Street"),
                    new TextData("Overdose of hallucinogenic nanobots"),

                    new TextData("Vincent\nNoir"),
                    new TextData("11/19/2068"),
                    new TextData("Laundry"),
                    new TextData("Shot in the neck with signs of physical combat"),

                    new TextData("Diane\nLevasseur"),
                    new TextData("11/20/2068"),
                    new TextData("Clandestine Factory"),
                    new TextData("Accidental explosion"),

                    new TextData("Jean\nTrouvé"),
                    new TextData("11/20/2068"),
                    new TextData("Maximum Height Residential"),
                    new TextData("Fall from 30 floors"),
                }
            },
            // Scene 13
            {
                TextGroup.MafiaOffice,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Why such a hidden place in a laundry? Are they laundering money?"),
                }
            },
            {
                TextGroup.MafiaVoicemail,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Mr. Revoir, some crazy person is trying to break into the lab. It would be a good idea to send reinforcements."),
                }
            },
            {
                TextGroup.MafiaDocument1,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Equipment purchase documents for the lab"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument2,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Book with names of clubgoers"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument3,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Debt-ridden addicts"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument4,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Document on managing chip lab"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument5,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "List of targets for experiments"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument6,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Psychological effects of frequent cover changes"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument7,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Collection of Chief Noir's new cover 3 months before the game date"), // TODO
                }
            },
            {
                TextGroup.MafiaAccessCard,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "This access card could be important for getting into a certain place."),
                }
            },
            // Scene 14
            {
                TextGroup.AlmostAtTheLab,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "The club is right there."),
                }
            },
            {
                TextGroup.CleaningRobot,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Hey, robot!"),
                    new TextData(TextType.Robot, "Not a robot, my name is Dobby the Domestic Robot."),
                    new TextData(TextType.Player, "Where's the club?"),
                    new TextData(TextType.Robot, "I don't know where the club is, that's a free robot thing."),
                }
            },
            {
                TextGroup.CleaningRobotGiveSocks,
                new List<TextData>()
                {
                    new TextData(TextType.Robot, "The club is that way."),
                    new TextData(TextType.Robot, "I'm a Free Robot now."),
                }
            },
            // Scene 15
            {
                TextGroup.ClubDoor,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "The club is closed, but the music is still playing loud?"),
                }
            },
            {
                TextGroup.ClubDoorUseAccessCard,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "There's no card reader on this door."),
                }
            },
            {
                TextGroup.ClubDoorUseFinger,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "There's no fingerprint reader here."),
                }
            },
            // Scene 16
            {
                TextGroup.BrainMiniGame,
                new List<TextData>()
                {
                    new TextData("Consciousness Extraction"),
                    new TextData("Zones"),
                    new TextData("Temporal"),
                    new TextData("Frontal"),
                    new TextData("Pariental"),
                    new TextData("Occipital"),
                    new TextData("Cerebellum"),
                    new TextData("Text about Temporal zone"),
                    new TextData("Text about Frontal zone"),
                    new TextData("Text about Pariental zone"),
                    new TextData("Text about Occipital zone"),
                    new TextData("Text about Cerebellum zone"),
                }
            },
            // TODO
        };

        public static readonly Dictionary<ItemGroup, List<ItemData>> Item = new()
        {
            {
                ItemGroup.Coke,
                new List<ItemData>()
                {
                    new ItemData("Coke", "Can of soda"),
                }
            },
            {
                ItemGroup.Julie_Drawing,
                new List<ItemData>()
                {
                    new ItemData("Julie's Drawing", "A drawing made by Julie"),
                }
            },
            {
                ItemGroup.TV_Manual,
                new List<ItemData>()
                {
                    new ItemData("TV Manual", "Manual for the new television"),
                }
            },
            {
                ItemGroup.Keys,
                new List<ItemData>()
                {
                    new ItemData("Keys", "House keys"),
                }
            },
            {
                ItemGroup.Pink_Sock,
                new List<ItemData>()
                {
                    new ItemData("Pink Sock", "A single pink sock"),
                }
            },
            {
                ItemGroup.Finger,
                new List<ItemData>()
                {
                    new ItemData("Severed Finger", ""),
                }
            },
            {
                ItemGroup.KeyCard,
                new List<ItemData>()
                {
                    new ItemData("Keycard", "Au-Revoir laboratory keycard"),
                }
            },
            {
                ItemGroup.Mafia_Doc_Equipment,
                new List<ItemData>()
                {
                    new ItemData("Mafia Equipment Document", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_Visitors,
                new List<ItemData>()
                {
                    new ItemData("Mafia Visitors Document", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_Addicts,
                new List<ItemData>()
                {
                    new ItemData("Mafia Addicts Document", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_TestSubjects,
                new List<ItemData>()
                {
                    new ItemData("Mafia Test Subjects Document", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_NewSleave,
                new List<ItemData>()
                {
                    new ItemData("Mafia New Sleave Document", ""),
                }
            },
            {
                ItemGroup.Chip_CEO,
                new List<ItemData>()
                {
                    new ItemData("CEO Chip", ""),
                }
            },
            {
                ItemGroup.Chip_Revolutionary,
                new List<ItemData>()
                {
                    new ItemData("Revolutionary Chip", ""),
                }
            },
        };
    }
}