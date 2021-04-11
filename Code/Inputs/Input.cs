using System;
using System.Collections.Generic;

namespace SwapperV2.Inputs
{
    public static class Input
    {
        static Bind GetBind(Settings.Binding binding) => new Bind()
        {
            Keys = binding.Keys, Buttons = binding.Buttons
        };

        public static Bind Right { get; private set; }
        public static Bind Left { get; private set; }
        public static Bind Up { get; private set; }
        public static Bind Down { get; private set; }
        public static Bind Swap { get; private set; }
        public static Bind Undo { get; private set; }

        public static void UpdateBinds()
        {
            Right = GetBind(Swapper.Instance.Settings.Right);
            Left = GetBind(Swapper.Instance.Settings.Left);
            Up = GetBind(Swapper.Instance.Settings.Up);
            Down = GetBind(Swapper.Instance.Settings.Down);
            Swap = GetBind(Swapper.Instance.Settings.Swap);
            Undo = GetBind(Swapper.Instance.Settings.Undo);
        }
    }
}
