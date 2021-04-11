using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SwapperV2.Inputs
{
    public class Bind
    {
        public Keys[] Keys;
        public Buttons[] Buttons;

        public bool Down, Up, Pressed, Released;

        public Bind()
        {
            Collector.OnCollect += Update;
        }

        ~Bind()
        {
            Collector.OnCollect -= Update;
        }

        public void Update()
        {
            Down = GetDown();
            Up = GetUp();
            Pressed = GetPressed();
            Released = GetReleased();
        }

        public bool GetDown()
        {
            foreach (var key in Keys)
            {
                if (Collector.Down(key)) return true;
            }

            foreach (var key in Buttons)
            {
                if (Collector.Down(key)) return true;
            }

            return false;
        }

        public bool GetUp() => !GetDown();

        public bool GetPressed()
        {
            foreach (var key in Keys)
            {
                if (Collector.Pressed(key)) return true;
            }

            foreach (var key in Buttons)
            {
                if (Collector.Pressed(key)) return true;
            }

            return false;
        }

        public bool GetReleased()
        {
            foreach (var key in Keys)
            {
                if (Collector.Released(key)) return true;
            }

            foreach (var key in Buttons)
            {
                if (Collector.Released(key)) return true;
            }

            return false;
        }
    }
}
