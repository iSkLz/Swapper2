using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SwapperV2.Graphics
{
    public class Image
    {
        public Texture2D Texture { get; }
        public Rectangle Clip { get; }

        public Image(Texture2D texture, Rectangle clip)
        {
            Texture = texture;
            Clip = clip;
        }

        public Image(Texture2D texture) : this(texture, new Rectangle(0, 0, texture.Width, texture.Height)) { }

        public Image Cut(Rectangle clip)
        {
            return new Image(Texture, new Rectangle(Clip.X + clip.X, Clip.Y + clip.Y, clip.Width, clip.Height));
        }
    }
}
