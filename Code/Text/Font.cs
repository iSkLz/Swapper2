using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;

using SwapperV2.Graphics;
using SwapperV2.Content;

namespace SwapperV2.Text
{
    public class Font
    {
        public enum Glyph
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Space
        }

        const int upperCase = 'A';
        const int lowerCase = 'a';

        SpriteSheet Sheet;

        public int Width { get; }
        public int Height { get; }

        public Font(Image image)
        {
            Sheet = new SpriteSheet(image, Width = image.Clip.Width / 37, Height = image.Clip.Height);
        }

        public Image GetImage(Glyph glyph)
        {
            return Sheet.Images[(int)glyph];
        }

        public Image GetImage(char chr)
        {
            if (chr == ' ')
            {
                return GetImage(Glyph.Space);
            }

            if (int.TryParse(chr.ToString(), out int res))
            {
                return GetImage(res + Glyph.Zero);
            }

            if (chr >= lowerCase)
                return GetImage((Glyph)(chr - lowerCase));
            else
                return GetImage((Glyph)(chr - upperCase));
        }

        public Image[] GetImages(string str)
        {
            return str.ToCharArray().Select((chr) => GetImage(chr)).ToArray();
        }
    }
}
