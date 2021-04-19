using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SwapperV2.Graphics
{
    public class SpriteSheet
    {
        public Image Sheet { get; }
        public int Width { get; }
        public int Height { get; }

        public Image[] Images { get; }

        /// <summary>
        /// Creates a sprite sheet
        /// </summary>
        /// <param name="sheet">Texture of the sheet</param>
        /// <param name="width">Width of one sprite</param>
        /// <param name="height">Height of one sprite</param>
        public SpriteSheet(Image sheet, int width, int height)
        {
            Sheet = sheet;
            Width = width;
            Height = height;

            Images = new Image[sheet.Clip.Width / width];

            for (int i = 0; i < Images.Length; i++)
            {
                Images[i] = Sheet.Cut(new Rectangle(i * Width, 0, Width, Height));
            }
        }

        /// <summary>
        /// Creates a sprite sheet
        /// </summary>
        /// <param name="sheet">Texture of the sheet</param>
        /// <param name="size">Width & height of one sprite</param>
        public SpriteSheet(Image sheet, int size) : this(sheet, size, size)
        {

        }
    }
}
