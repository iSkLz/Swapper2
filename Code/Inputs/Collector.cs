using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SwapperV2.Inputs
{
    public static class Collector
    {
        public static KeyboardState CurrentKState;
        public static KeyboardState PreviousKState;

        public static GamePadState CurrentGState;
        public static GamePadState PreviousGState;

        public static MouseState CurrentMState;
        public static MouseState PreviousMState;

        public enum MouseButton
        {
            Left, Middle, Right
        }

        public static event Action OnCollect;

        static Collector()
        {
            Swapper.OnUpdate += Update;
            Swapper.OnEndUpdate += EndUpdate;
        }

        private static void Update(float delta)
        {
            CurrentGState = GamePad.GetState(PlayerIndex.One);
            if (PreviousGState == null) PreviousGState = CurrentGState;

            CurrentKState = Keyboard.GetState();
            if (PreviousKState == null) PreviousKState = CurrentKState;

            CurrentMState = Mouse.GetState();
            if (PreviousMState == null) PreviousMState = CurrentMState;

            OnCollect?.Invoke();
        }

        private static void EndUpdate(float obj)
        {
            PreviousKState = CurrentKState;
            PreviousGState = CurrentGState;
        }

        #region Mouse
        public static Vector2 Cursor()
        {
            return new Vector2(CurrentMState.X, CurrentMState.Y);
        }

        public static bool Down(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Middle:
                    return CurrentMState.MiddleButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return CurrentMState.RightButton == ButtonState.Pressed;
                default:
                    return CurrentMState.LeftButton == ButtonState.Pressed;
            }
        }

        public static bool Up(MouseButton button)
        {
            return !Down(button);
        }

        public static bool Pressed(MouseButton button)
        {
            if (Up(button)) return false;

            switch (button)
            {
                case MouseButton.Middle:
                    return PreviousMState.MiddleButton == ButtonState.Released;
                case MouseButton.Right:
                    return PreviousMState.RightButton == ButtonState.Released;
                default:
                    return PreviousMState.LeftButton == ButtonState.Released;
            }
        }

        public static bool Released(MouseButton button)
        {
            if (Down(button)) return false;

            switch (button)
            {
                case MouseButton.Middle:
                    return PreviousMState.MiddleButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return PreviousMState.RightButton == ButtonState.Pressed;
                default:
                    return PreviousMState.LeftButton == ButtonState.Pressed;
            }
        }

        public static int Wheel()
        {
            return CurrentMState.ScrollWheelValue - PreviousMState.ScrollWheelValue;
        }
        #endregion

        #region Keyboard
        public static bool Down(Keys key)
        {
            return CurrentKState.IsKeyDown(key);
        }

        public static bool Up(Keys key) => !Down(key);

        public static bool Pressed(Keys key)
        {
            return Down(key) && PreviousKState.IsKeyUp(key);
        }

        public static bool Released(Keys key)
        {
            return Up(key) && PreviousKState.IsKeyDown(key);
        }
        #endregion

        #region Controller
        public static bool Down(Buttons button)
        {
            return CurrentGState.IsButtonDown(button);
        }

        public static bool Up(Buttons button) => !Down(button);

        public static bool Pressed(Buttons button)
        {
            return Down(button) && PreviousGState.IsButtonUp(button);
        }

        public static bool Released(Buttons button)
        {
            return Up(button) && PreviousGState.IsButtonDown(button);
        }
        #endregion

        // TODO: Analog
    }
}
