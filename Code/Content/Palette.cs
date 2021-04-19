using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace SwapperV2.Content
{
    public static class Palette
    {
        public static Color Purple = new Color(0x9e, 0x44, 0x91);
        public static Color Red = new Color(0xbd, 0x51, 0x5a);
        public static Color Blue = new Color(0x42, 0x5b, 0xbd);
        public static Color Blank = new Color(0x23, 0x21, 0x3d);
        public static Color Void = new Color(0x76, 0x74, 0x7d);
        public static Color Gold = new Color(0xf3, 0xd0, 0x40);
        public static Color Silver = new Color(0x76, 0x74, 0x7d);
        public static Color Bronze = new Color(0xd1, 0x7f, 0x6b);
        public static Color Green = new Color(0x82, 0xaa, 0x28);
        public static Color Object = new Color(0x57, 0x54, 0x6f);
        public static Color Brown = new Color(0x94, 0x58, 0x48);
        public static Color Pink = new Color(0xd9, 0x5b, 0x9a);

        #region Enum
        public enum Colors : byte
        {
            Red, Blue, Blank, Void, Purple, Gold, Silver, Bronze, Green, Object, Pink, Brown, White
        }

        public static Color GetColor(Colors color)
        {
            switch (color)
            {
                case Colors.Purple:
                    return Purple;
                case Colors.Red:
                    return Red;
                case Colors.Blue:
                    return Blue;
                case Colors.Blank:
                    return Blank;
                case Colors.Void:
                    return Void;
                case Colors.Gold:
                    return Gold;
                case Colors.Silver:
                    return Silver;
                case Colors.Bronze:
                    return Bronze;
                case Colors.Green:
                    return Green;
                case Colors.Object:
                    return Object;
                case Colors.Pink:
                    return Pink;
                case Colors.Brown:
                    return Brown;
                default:
                    return Color.White;
            }
        }

        private static Colors ToColors(Constants.TileColor tileColor)
            => (Colors)tileColor;

        private static Colors ToColors(Constants.FlagColor flagColor)
            => (byte)flagColor + Colors.Gold;

        private static Colors ToColors(Constants.RemoteType remoteColor)
        {
            if (remoteColor <= Constants.RemoteType.Blue)
                return (Colors)remoteColor;
            else if (remoteColor == Constants.RemoteType.Purple)
                return Colors.Purple;
            else if (remoteColor <= Constants.RemoteType.Silver)
                return remoteColor - Constants.RemoteType.Gold + Colors.Gold;
            else
                return Colors.White;
        }

        public static Color GetColor(Constants.TileColor tileColor)
            => GetColor(ToColors(tileColor));

        public static Color GetColor(Constants.FlagColor tileColor)
            => GetColor(ToColors(tileColor));

        public static Color GetColor(Constants.RemoteType remoteColor)
            => GetColor(ToColors(remoteColor));
        #endregion
    }
}
