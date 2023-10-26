using Assets.Script.Locale;
using System.Collections.Generic;

namespace Assets.Script.Dialog
{
    public static class AllDialogs
    {
        public static Dictionary<TextGroup, List<object>> Sequence = new()
        {
            {
                TextGroup.DialogWakeUpCall,
                new List<object>()
            {
                0, 1, 2,
                new Dictionary<int, List<object>>()
                {
                    {
                        3,
                        new List<object>()
                        {
                            4, 5
                        }
                    },
                    {
                        6,
                        new List<object>()
                        {
                            7, 8
                        }
                    },
                },
                9,
            }
            },
        };
    }
}
