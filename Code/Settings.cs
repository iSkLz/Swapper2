using System;
using System.IO;
using System.Xml.Serialization;

using Microsoft.Xna.Framework.Input;

namespace SwapperV2
{
    public class Settings
    {
        #region Save/Load
        static XmlSerializer Serializer = XmlSerializer.FromTypes(new Type[] { typeof(Settings) })[0];

        public static Settings Load()
        {
            try
            {
                Settings obj;

                using (Stream stream = new FileStream("Settings.xml", FileMode.Open, FileAccess.Read))
                {
                    obj = (Settings)Serializer.Deserialize(stream);
                }

                return obj;
            }
            catch
            {
                return new Settings();
            }
        }

        public void Save()
        {
            using (Stream stream = new FileStream("Settings.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                Serializer.Serialize(stream, this);
            }
        }
        #endregion

        public struct Binding
        {
            public Keys[] Keys;
            public Buttons[] Buttons;
        }

        #region Controls
        public Binding Right = new Binding() {
            Keys = new Keys[]
            {
                Keys.D, Keys.Right
            },
            Buttons = new Buttons[]
            {
                Buttons.DPadRight
            }
        };

        public Binding Left = new Binding()
        {
            Keys = new Keys[]
            {
                Keys.A, Keys.Left
            },
            Buttons = new Buttons[]
            {
                Buttons.DPadLeft
            }
        };

        public Binding Up = new Binding()
        {
            Keys = new Keys[]
            {
                Keys.W, Keys.Up
            },
            Buttons = new Buttons[]
            {
                Buttons.DPadUp
            }
        };

        public Binding Down = new Binding()
        {
            Keys = new Keys[]
            {
                Keys.S, Keys.Down
            },
            Buttons = new Buttons[]
            {
                Buttons.DPadDown
            }
        };

        public Binding Swap = new Binding()
        {
            Keys = new Keys[]
            {
                Keys.Space
            },
            Buttons = new Buttons[]
            {
                Buttons.A
            }
        };

        public Binding Undo = new Binding()
        {
            Keys = new Keys[]
            {
                Keys.Q
            },
            Buttons = new Buttons[]
            {
                Buttons.B
            }
        };
        #endregion
    }
}
