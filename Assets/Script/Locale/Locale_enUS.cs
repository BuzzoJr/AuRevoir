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
                TextGroup.LockedDoor,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Locked"),
                }
            },
            {
                TextGroup.LockedDoorLab,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Locked, I need some Keycard"),
                }
            },
            {
                TextGroup.LockedDoorLaundry,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Fingerprint lock"),
                    new TextData(TextType.PlayerThinking, "Unfortunately my finger is not the default password"),
                }
            },
            {
                TextGroup.Inventory,
                new List<TextData>()
                {
                    new TextData("None"),
                    new TextData("> INVENTORY"),
                    new TextData("11/21/2068"),
                    new TextData("USE ITEM"),
                    new TextData("INSPECT ITEM"),
                    new TextData("Fechar"),
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
            {
                TextGroup.LockedDoorOffice,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "I should talk to the boss first."),
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
                    new TextData(TextType.RevolutionaryHidden, "Can you spare some change?"),
                }
            },
            {
                TextGroup.DirectionsToLaundry,
                new List<TextData>()
                {
                    new TextData(TextType.RevolutionaryHidden, "I've never seen you around here... Are you here to stir up more trouble?"),
                    new TextData(TextType.Player, "No, I'm looking for a Laundry."),
                    new TextData(TextType.RevolutionaryHidden, "You're right next to it."),
                    new TextData(TextType.RevolutionaryHidden, "I just don't think you'll want to wash your clothes there."),
                    new TextData(TextType.Player, "Thank you."),
                }
            },
            {
                TextGroup.DirectionsToMorgue,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Have you seen anyone carrying a body around here?"),
                    new TextData(TextType.RevolutionaryHidden, "A body? Have you thought about checking the morgue?"),
                    new TextData(TextType.Player, "Good idea! Thank you."),
                    new TextData(TextType.RevolutionaryHidden, "Follow this street, and you'll find what you're looking for."),
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
                TextGroup.LaundrySign,
                new List<TextData>()
                {
                    new TextData("Laundry"),
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
            {
                TextGroup.MorgueButtonCorrect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "The data from this body matches the given information."),
                }
            },
            {
                TextGroup.MorgueButtonWrong,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "I think this doesn't make sense..."),
                }
            },
            {
                TextGroup.MorgueFinger,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "The victim's finger suddenly fell off, this could come in handy."),
                }
            },
            {
                TextGroup.MorgueCorpseVincent,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "That's strange, the chip isn't here."),
                    new TextData(TextType.PlayerThinking, "I need to investigate further."),
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
                    new TextData(TextType.PlayerThinking, "Psychological effects of frequent sleeve changes"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument7,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Collection of Chief Noir's new sleeve 3 months before the game date"), // TODO
                }
            },
            {
                TextGroup.MafiaAccessCard,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "This access card could be important for getting into a certain place."),
                }
            },
            {
                TextGroup.CutsceneNotWatched,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "A better look at that computer before leaving might be a good idea."),
                }
            },
            {
                TextGroup.CutsceneLab,
                new List<TextData>()
                {
                    new TextData(TextType.LabWorker1, 5f, "Keep working... keep working..."),
                    new TextData(TextType.LabWorker1, 4f, "What happened to subject number 3?"),
                    new TextData(TextType.LabWorker2, 4f, "Do you mean Vincent Noir, sir?"),
                    new TextData(TextType.LabWorker1, 8f, "Stop using names! They are subject number X from the moment they entered this door."),
                    new TextData(TextType.LabWorker2, 3f, "Sorry, sir."),
                    new TextData(TextType.LabWorker2, 8f, "The experiment was unsuccessful this time and unfortunetly Vin... subject number 3 didn't survived."),
                    new TextData(TextType.LabWorker1, 4f, "Again? You are all incompetent!"),
                    new TextData(TextType.LabWorker2, 7f, "I also have good news. His body is totally compatible with the Boss."),
                    new TextData(TextType.LabWorker1, 4f, "Good. Prepare the new \"sleeve\" for the Boss."),
                    new TextData(TextType.LabWorker2, 3f, "I'm on it, sir."),
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
                TextGroup.BrainHUD,
                new List<TextData>()
                {
                    new TextData("Consciousness Extraction"),
                    new TextData("Quit"),
                }
            },
            {
                TextGroup.BrainMenu,
                new List<TextData>()
                {
                    new TextData("Zones"),
                    new TextData("Temporal"),
                    new TextData("Frontal"),
                    new TextData("Parietal"),
                    new TextData("Occipital"),
                    new TextData("Cerebellum"),
                }
            },
            {
                TextGroup.BrainInstructions,
                new List<TextData>()
                {
                    new TextData(""),
                    new TextData("\tThe temporal lobe is crucial for the processing of auditory information and is intrinsically linked to memory formation. It houses the hippocampus, a key structure in memory consolidation. Additionally, the temporal lobe is associated with language comprehension and plays a role in recognizing faces and objects.\n\n\tTo correctly extract data, the temporal lobe should be the third to be activated."),
                    new TextData("\tThe frontal lobe is often considered the site of executive functions. It is responsible for decision-making, problem-solving, and control of social behavior. This area, especially the prefrontal cortex, is fundamental for personality development, emotional regulation, and the ability to plan for the future.\n\n\tFor the extraction process, we should always start with the right frontal lobe and then move to the left shortly after connecting the temporal lobe."),
                    new TextData("\tThe parietal lobe is involved in processing sensory information from the external environment, including touch and spatial perception. It integrates inputs from various senses to create a coherent perception of the surrounding world.\n\n\tTo connect the parietal lobe, ensure that all frontal lobes are activated."),
                    new TextData("\tThe occipital lobe is primarily responsible for visual processing. It receives and interprets signals from the eyes, allowing people to perceive and understand the visual world.\n\n\tThe right time to connect the occipital lobe is right after completing any connections of the frontal lobe."),
                    new TextData("\tAlthough often associated with motor coordination, the cerebellum also plays a role in cognitive functions. It helps adjust movements, balance, and posture. Additionally, the cerebellum is implicated in certain aspects of language processing and contributes to procedural memory.\n\n\tAs the cerebellum deals with cognitive functions, we must leave it for the end."),
                    new TextData("Select an item from the menu on the side"),
                    new TextData("Extraction successful!\n\nThe subject's cape is now disposable."),
                }
            },
            {
                TextGroup.LabDiscussion,
                new List<TextData>()
                {
                    new TextData(TextType.Revolutionary, "Hey! You there."),
                    new TextData(TextType.Player, "What are you doing in there?"),
                    new TextData(TextType.Player, "Are you some kind of guinea pig for science experiments?"),
                    new TextData(TextType.Revolutionary, "It seems that you don't remember me."),
                    new TextData(TextType.Revolutionary, "Before my answer, I need you to answer my question."),
                    new TextData(TextType.Revolutionary, "Are you looking for some kind of chip? Maybe like this one in my hand?"),
                    new TextData(TextType.Player, "What? Why did you... ?"),
                    // Special - Closes the door
                    new TextData(TextType.Revolutionary, "Gotcha Sentinel!"),
                    new TextData(TextType.Player, "Give the chip and let me out! NOW!"),
                    new TextData(TextType.Revolutionary, "I'm sorry friend, but I won't let you go now."),
                    new TextData(TextType.Revolutionary, "And don't think about getting me out of here, because this experiment pod is strong."),
                    new TextData(TextType.Revolutionary, "Usually it is used to avoid people from getting out."),
                    new TextData(TextType.Player, "What do you want from me?"),
                    new TextData(TextType.Revolutionary, "Just to tell you a little bit more. Curious?"),
                    new TextData(TextType.Player, "Why should I be curious? I'm just doing my job."),
                    new TextData(TextType.Player, "I just need to get out of here. With the chip."),
                    new TextData(TextType.Revolutionary, "So you don't know whose consciousness is within this chip!"),
                    new TextData(TextType.Player, "I was told not to question and I cannot afford a failure at thie job. Not today."),
                    new TextData(TextType.Revolutionary, "You are in a much bigger problem than failing your simple job, Sentinel!"),
                    new TextData(TextType.Revolutionary, "This little chip contains the great mind of a terrorist!"),
                    new TextData(TextType.Revolutionary, "A terrorist who took my brother's body and used as a mere \"sleeve\"."),
                    new TextData(TextType.Revolutionary, "Have you ever heard of the name René Revoir?"),
                    new TextData(TextType.Player, "The only René Revoir I know exists is the CEO of Au Revoir, but nothing related to this place."),
                    new TextData(TextType.Revolutionary, "You are both correct and incorrect my friend."),
                    new TextData(TextType.Revolutionary, "We are talking about the CEO of Au Revoir, but you are wrong about his relations."),
                    new TextData(TextType.Revolutionary, "Look at the equipments around you and count how manyu Au Revoir logos there are."),
                    new TextData(TextType.Player, "Why would this great man come here? Are these his experiments?"),
                    new TextData(TextType.Revolutionary, "Here the lab where new tecnology is conceived. Using humans without remorse."),
                    new TextData(TextType.Revolutionary, "Here is where my brother died after being kidnapped."),
                    new TextData(TextType.Revolutionary, "They disappear after having some fun in the club behind these walls."),
                    new TextData(TextType.Revolutionary, "But they did much worst with my brother. They made him look like a terrorist."),
                    new TextData(TextType.Revolutionary, "René Revoir used my brother's corpse as his own personal \"sleeve\"."),
                    new TextData(TextType.Revolutionary, "Everyone thought Vincent Noir joined the mafia, but only I knew the truth."),
                    new TextData(TextType.Player, "That name... I saw his body on the morgue."),
                    new TextData(TextType.Revolutionary, "That was the only way. I had to do it."),
                    new TextData(TextType.Player, "You killed your own brother?"),
                    new TextData(TextType.Revolutionary, "I killed René Revoir!"),
                    new TextData(TextType.Revolutionary, "Now I must rely the fate of my family and so many others in your hands."),
                    new TextData(TextType.Player, "What do you mean?"),
                    new TextData(TextType.Revolutionary, "I was waiting for you to come here and discover by your self what transpired."),
                    new TextData(TextType.Revolutionary, "If I have told you at the moment you jumped out of the sewers you wouldn't belive me."),
                    new TextData(TextType.Player, "So... you were the beggar! Have you being spying on me?"),
                    new TextData(TextType.Revolutionary, "It was the only way. And now I must trust that you with my life."),
                    new TextData(TextType.Player, "I have nothing to do with you and your life."),
                    new TextData(TextType.Revolutionary, "You will be able to leave soon, don't worry. But first, you must use this brain machine."),
                    new TextData(TextType.Revolutionary, "That machine is able to extract my consciousness and store it on a chip."),
                    new TextData(TextType.Revolutionary, "After that, this pod will open with my mindless body and you will be able to take a chip."),
                    new TextData(TextType.Revolutionary, "But I beg you to take my chip instead of this terrorist's chip."),
                    new TextData(TextType.Revolutionary, "Take me to the top of Au Revoir and I will be able to stop this madness."),
                    new TextData(TextType.Revolutionary, "And with that power, I will be able to help you retire much sooner than you expected."),
                    new TextData(TextType.Revolutionary, "The choice is yours..."),
                }
            },
            {
                TextGroup.LabPickUpChips,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Finally! Here are the chips. One contains the CEO and the other for this crazy revolutionary."),
                }
            },
            {
                TextGroup.FinalDecision,
                new List<TextData>()
                {
                    new TextData("Final decision:\nWhich Chip will you deliver?"),
                }
            },
            {
                TextGroup.EndScene,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Look who's back, everything worked out?"),
                    new TextData(TextType.Player, "Yes boss, here it is."),
                    new TextData(TextType.Player, "CEO's CHIP"),
                    new TextData(TextType.Player, "Revolutionary's CHIP"),
                }
            },
            {
                TextGroup.Places,
                new List<TextData>()
                {
                    new TextData("After Life"),
                    new TextData("Morgue"),
                }
            },
            {
                TextGroup.Credits,
                new List<TextData>()
                {
                    new TextData("Thank's for playing!"),
                    new TextData("Made by \r\n\r\nEric Gama Müller\r\nLeonardo Pedroso\r\nOsny Buzzo Junior"),
                }
            },
        };

        public static readonly Dictionary<ItemGroup, List<ItemData>> Item = new()
        {
            {
                ItemGroup.Coke,
                new List<ItemData>()
                {
                    new ItemData(1,  "Coke", "Can of soda"),
                }
            },
            {
                ItemGroup.Julie_Drawing,
                new List<ItemData>()
                {
                    new ItemData(2,  "Julie's Drawing", "A drawing made by Julie"),
                }
            },
            {
                ItemGroup.TV_Manual,
                new List<ItemData>()
                {
                    new ItemData(3,  "TV Manual", "Manual for the new television"),
                }
            },
            {
                ItemGroup.Keys,
                new List<ItemData>()
                {
                    new ItemData(4,  "Keys", "House keys"),
                }
            },
            {
                ItemGroup.Pink_Sock,
                new List<ItemData>()
                {
                    new ItemData(5,  "Pink Sock", "A single pink sock"),
                }
            },
            {
                ItemGroup.Finger,
                new List<ItemData>()
                {
                    new ItemData(6,  "Severed Finger", ""),
                }
            },
            {
                ItemGroup.KeyCard,
                new List<ItemData>()
                {
                    new ItemData(7,  "Keycard", "Au-Revoir laboratory keycard"),
                }
            },
            {
                ItemGroup.Mafia_Doc_Equipment,
                new List<ItemData>()
                {
                    new ItemData(8,  "Au Revoir Lab Equipment Receipt", "Laboratory Equipment Collection Receipt.", "Laboratory Equipment Collection Receipt."),
                }
            },
            {
                ItemGroup.Mafia_Doc_Visitors,
                new List<ItemData>()
                {
                    new ItemData(9,  "Club Visitors", "Frequent visitors to the Snake Pit", "Frequent visitors to the Snake Pit"),
                }
            },
            {
                ItemGroup.Mafia_Doc_Addicts,
                new List<ItemData>()
                {
                    new ItemData(10, "Mafia Addicts Debtors", "List of drug addicts who owe to the mafia.", "Document with the list of drug addicts who owe to the mafia."),
                }
            },
            {
                ItemGroup.Mafia_Doc_TestSubjects,
                new List<ItemData>()
                {
                    new ItemData(11, "Mafia Test Subjects", "Target List for Biological Tests.", "Target List for Biological Tests."),
                }
            },
            {
                ItemGroup.Mafia_Doc_NewSleeve,
                new List<ItemData>()
                {
                    new ItemData(12, "New sleeve Report", "Report for the mafia boss's new sleeve", "Preparation completion report for the mafia boss's new sleeve."),
                }
            },
            {
                ItemGroup.Chips,
                new List<ItemData>()
                {
                    new ItemData(13, "Chips Au Revoir", "CEO's and Revolutionary's Chips"),
                }
            },
        };
    }
}