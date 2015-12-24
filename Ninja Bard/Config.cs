﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Bard
{
    public static class Config
    {
        private const string MenuName = "Ninja Bard";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Bard by Zpitty");
            Menu.AddLabel("Please Report any Bugs/Suggestions to the Forum Post!");

            Modes.Initialize();
            Draw.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                Menu = Config.Menu.AddSubMenu("Modes");

                Combo.Initialize();
                Menu.AddSeparator();
                Harass.Initialize();
                Menu.AddSeparator();
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _qBindDistance;
                private static readonly Slider _qAccuracyPercent;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static int QBindDistance
                {
                    get { return _qBindDistance.CurrentValue; }
                }

                public static int QAccuracyPercent
                {
                    get { return _qAccuracyPercent.CurrentValue; }
                }
                static Combo()
                {
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q to Stun"));
                    _qBindDistance = Menu.Add("qBind", new Slider("Q Bind Distance to Wall", 300, 100, 350));
                    _qAccuracyPercent = Menu.Add("qAccuracy", new Slider("Q Accuracy % to Wall", 80, 0, 100));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _manaQ;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static int ManaQ
                {
                    get { return _manaQ.CurrentValue; }
                }

                

                static Harass()
                {
                    Menu.AddGroupLabel("Harass");
                    _useQ = Menu.Add("harrasQ", new CheckBox("Use Q always"));
                    _manaQ = Menu.Add("QMana", new Slider("Use Q until % Mana", 40));

                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly CheckBox _enablePotion;
                private static readonly CheckBox _disableMAA;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useQKS;
                private static readonly CheckBox _RInterrupt;
                private static readonly CheckBox _qGapcloser;
                private static readonly Slider _rInterruptDelay;
                private static readonly Slider _wMana;
                private static readonly Slider _minHPPotion;
                private static readonly Slider _minMPPotion;
                private static readonly Slider _wHeal;
                private static readonly CheckBox _igniteKS;


                public static bool EnablePotion
                {
                    get { return _enablePotion.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool DisableMAA
                {
                    get { return _disableMAA.CurrentValue; }
                }
                public static bool UseQKS
                {
                    get { return _useQKS.CurrentValue; }
                }
                public static bool RInterrupt
                {
                    get { return _RInterrupt.CurrentValue; }
                }

                public static bool QGapcloser
                {
                    get { return _qGapcloser.CurrentValue; }
                }
                public static int WMana
                {
                    get { return _wMana.CurrentValue; }
                }

                public static int MinHPPotion
                {
                    get { return _minHPPotion.CurrentValue; }
                }

                public static int RInterruptDelay
                {
                    get { return _rInterruptDelay.CurrentValue; }
                }

                public static int WHeal
                {
                    get { return _wHeal.CurrentValue; }
                }

                public static int MinMPPotion
                {
                    get { return _minMPPotion.CurrentValue; }
                }
                public static bool IgniteKS
                {
                    get { return _igniteKS.CurrentValue; }
                }

                

                static Misc()
                {
                    Menu.AddGroupLabel("Misc");
                    _RInterrupt = Menu.Add("InterruptR", new CheckBox("Use R to interrupt"));
                    _qGapcloser = Menu.Add("GapcloseQ", new CheckBox("Use Q on gapcloser"));
                    _rInterruptDelay = Menu.Add("InterruptRDelay", new Slider("R Interrupt Delay (ms)", 500, 0, 1000));
                    Menu.AddSeparator();
                    _useQKS = Menu.Add("QKS", new CheckBox("Use Q to KS"));
                    _useW = Menu.Add("WUse", new CheckBox("Auto use W to heal Self/Ally"));
                    _disableMAA = Menu.Add("disablemAA", new CheckBox("Don't Auto Attack Minions"));
                    _wHeal = Menu.Add("healW", new Slider("Use at % Health", 40));
                    _wMana = Menu.Add("manaW", new Slider("Use W until % Mana", 20));
                    Menu.AddSeparator();
                    Menu.AddGroupLabel("Utility");
                    _igniteKS = Menu.Add("KSIgnite", new CheckBox("Use Ignite to KS"));
                    _enablePotion = Menu.Add("Potion", new CheckBox("Use Potions"));
                    _minHPPotion = Menu.Add("minHPPotion", new Slider("Use at % Health", 60));
                    _minMPPotion = Menu.Add("minMPPotion", new Slider("Use at % Mana", 20));

                }

                public static void Initialize()
                {
                }
            }
        }

        public static class Draw
        {
            public static readonly Menu DMenu;
            static Draw()
            {

                DMenu = Config.Menu.AddSubMenu("Draw Menu");

                DrawMenu.Initialize();
            }
            public static void Initialize()
            {
            }

            public static class DrawMenu
            {
                public static readonly CheckBox _drawQ;
                public static readonly CheckBox _drawW;
                public static readonly CheckBox _drawR;

                public static Menu MainMenu
                {
                    get { return DMenu; }
                }


                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawW
                {
                    get { return _drawW.CurrentValue; }
                }


                public static bool DrawR
                {
                    get { return _drawR.CurrentValue; }
                }

                static DrawMenu()
                {
                    DMenu.AddGroupLabel("Draw Options");
                    DMenu.AddSeparator();
                    _drawQ = DMenu.Add("QDraw", new CheckBox("Draw Q"));
                    _drawW = DMenu.Add("WDraw", new CheckBox("Draw W"));
                    _drawR = DMenu.Add("RDraw", new CheckBox("Draw R"));
                }

                public static void Initialize()
                {
                }

            }
        }
    }
}