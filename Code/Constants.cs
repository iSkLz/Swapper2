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
            Purple, Red, Blue, Blank, Void
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
            Gold, Blue, Red, None
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

        public enum Colors : byte
        {
            Purple, Red, Blue, Blank, Void, Gold, Silver, Bronze, Green
        }
#endregion

        public static Dictionary<Colors, Color> ColorsDict = new Dictionary<Colors, Color>()
        {
            {
                Colors.Purple, new Color(0x9e, 0x44, 0x91)
            },
            {
                Colors.Red, new Color(0xbd, 0x51, 0x5a)
            },
            {
                Colors.Blue, new Color(0x42, 0x5b, 0xbd)
            },
            {
                Colors.Blank, new Color(0x23, 0x21, 0x3d)
            },
            {
                Colors.Void, new Color(0x76, 0x74, 0x7d)
            },
            {
                Colors.Gold, new Color(0xf3, 0xd0, 0x40)
            },
            {
                Colors.Silver, new Color(0x76, 0x74, 0x7d)
            },
            {
                Colors.Bronze, new Color(0xd1, 0x7f, 0x6b)
            },
            {
                Colors.Green, new Color(0x82, 0xaa, 0x28)
            },
        };

        #region Rotation
        public const float FullCircle = 2 * (float)Math.PI;
        public const float HalfCircle = (float)Math.PI;
        public const float QuarterCircle = 0.5f * (float)Math.PI;
        public const float EighthCircle = 0.25f * (float)Math.PI;
        #endregion
    }
}
