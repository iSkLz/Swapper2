using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SwapperV2
{
    public static class Constants
    {
        #region Enums
        public enum TileColor : byte
        {
            Red, Blue, Blank, Void, Purple
        }

        public enum FlagColor : byte
        {
            Gold, Silver, Bronze, Normal
        }

        public enum KeyType : byte
        {
            Gold, Silver, Bronze
        }

        public enum RemoteType : byte
        {
            Red, Blue, Purple, Gold, Silver, None
        }

        public enum RemoteShape : byte
        {
            Circle, Rectangle, Triangle, None
        }

        public enum Direction : byte
        {
            Left = 1,
            Up = 2,
            Right = 4,
            Down = 8,
            UpLeft = Up | Left,
            DownLeft = Down | Left,
            UpRight = Up | Right,
            DownRight = Down | Right
        }
        #endregion

        #region Rotation
        public const float FullCircle = 2 * (float)Math.PI;
        public const float HalfCircle = (float)Math.PI;
        public const float QuarterCircle = 0.5f * (float)Math.PI;
        public const float EighthCircle = 0.25f * (float)Math.PI;
        #endregion
    }
}
