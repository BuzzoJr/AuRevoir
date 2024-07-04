using Assets.Script.Locale;
using System.Collections.Generic;

namespace Assets.Script.Dialog
{
    public static class AllDialogs
    {
        public static float defaultDelay = 120f;

        public static Dictionary<TextGroup, List<object>> Sequence = new()
        {
            {
                TextGroup.ChatWithHank,
                new List<object>()
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, DialogAction.Special, 16, DialogAction.Special, 17, 18, 19, 20, 21, 22, DialogAction.Special, 23, DialogAction.Special
                }
            },
            {
                TextGroup.CarCrashPoliceOfficer,
                new List<object>()
                {
                    0, 1, 2, 3, 4, 5, 6, DialogAction.Special
                }
            },
            {
                TextGroup.CarCrashClient,
                new List<object>()
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 11,
                    new Dictionary<int, List<object>>()
                    {
                        {
                            12,
                            new List<object>()
                            {
                                13,
                            }
                        },
                        {
                            14,
                            new List<object>()
                            {
                                15,
                            }
                        },
                        {
                            16,
                            new List<object>()
                            {
                                17,
                            }
                        },
                    },
                    new Dictionary<int, List<object>>()
                    {
                        {
                            18,
                            new List<object>()
                            {
                                19,
                            }
                        },
                        {
                            20,
                            new List<object>()
                            {
                                21,
                            }
                        },
                        {
                            22,
                            new List<object>()
                            {
                                23,
                            }
                        },
                    },
                    new Dictionary<int, List<object>>()
                    {
                        {
                            24,
                            new List<object>()
                            {
                                25,
                            }
                        },
                        {
                            26,
                            new List<object>()
                            {
                                27,
                            }
                        },
                        {
                            28,
                            new List<object>()
                            {
                                29,
                            }
                        },
                    },
                    30, 31, 32, 33,
                }
            },

            {
                TextGroup.CarCrashDelivery,
                new List<object>()
                {
                    0, 1, 2, 3, 4, 5, DialogAction.Special,
                }
            },
            {
                TextGroup.DialogWakeUpCall,
                new List<object>()
                {
                    DialogAction.Special, 0, 1, 2,
                    new Dictionary<int, List<object>>()
                    {
                        {
                            3,
                            new List<object>()
                            {
                                4, 5,
                            }
                        },
                        {
                            6,
                            new List<object>()
                            {
                                7, 8,
                            }
                        },
                    },
                    9, DialogAction.RemoveDialog,
                }
            },
            {
                TextGroup.TVNews,
                new List<object>()
                {
                    DialogAction.Special, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
                }
            },
            {
                TextGroup.BossOfferMisson,
                new List<object>()
                {
                    DialogAction.Special,0, 1, 2, 3, 4, 5, 6,
                    new Dictionary<int, List<object>>()
                    {
                        {
                            7,
                            new List<object>()
                            {
                                8,
                            }
                        },
                        {
                            9,
                            new List<object>()
                            {
                                10, 11, 12, 13, 14, 15,
                            }
                        },
                    },
                    16, 17, 18, 19, 20,
                }
            },
            {
                TextGroup.BossMoreInfo,
                new List<object>()
                {
                    new Dictionary<int, List<object>>()
                    {
                        {
                            0,
                            new List<object>()
                            {
                                1, 2,
                            }
                        },
                        {
                            3,
                            new List<object>()
                            {
                                4, 5,
                            }
                        },
                    }
                }
            },
            {
                TextGroup.WallGuard,
                new List<object>()
                {
                    0,
                    new Dictionary<int, List<object>>()
                    {
                        {
                            1,
                            new List<object>()
                            {
                                1, 2,
                            }
                        },
                        {
                            3,
                            new List<object>()
                            {
                                3, 4,
                            }
                        },
                        {
                            5,
                            new List<object>()
                            {
                                5, 6,
                            }
                        },
                    },
                }
            },
            {
                TextGroup.SewersRobot,
                new List<object>()
                {
                    0, 1, 2, 3,
                    new Dictionary<int, List<object>>()
                    {
                        {
                            4,
                            new List<object>()
                            {
                                4, 5, 6,
                            }
                        },
                        {
                            7,
                            new List<object>()
                            {
                                7, 8
                            }
                        },
                    },
                    9,
                }
            },
            {
                TextGroup.DirectionsToLaundry,
                new List<object>()
                {
                    0, 1, 2, 3, 4,
                }
            },
            {
                TextGroup.DirectionsToMorgue,
                new List<object>()
                {
                    0, 1, 2, 3,
                }
            },
            {
                TextGroup.LaundryMachine16UseFail,
                new List<object>()
                {
                    0, DialogAction.Special, 1,
                }
            },
            {
                TextGroup.Homeless,
                new List<object>()
                {
                    0, 1,
                    new Dictionary<int, List<object>>()
                    {
                        {
                            2,
                            new List<object>()
                            {
                                3, 4,
                            }
                        },
                        {
                            5,
                            new List<object>()
                            {
                                6, 7, 8, 14,
                            }
                        },
                        {
                            9,
                            new List<object>()
                            {
                                10, 11, 12, 13, 14,
                            }
                        },
                    },
                }
            },
            {
                TextGroup.EndScene,
                new List<object>()
                {
                    0, 1,
                    new Dictionary<int, List<object>>()
                    {
                        {
                            2,
                            new List<object>()
                            {
                                DialogAction.Special,
                            }
                        },
                        {
                            3,
                            new List<object>()
                            {
                               DialogAction.Special,
                            }
                        },
                    },
                }
            },
        };
    }
}
