using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SwapperV2.World;

namespace SwapperV2.Graphics
{
    public class Sprite : Component
    {
        public Image Image;

        public Color Tint = Color.White;
        public Color? Outline = null;
        public float OutlineSize = 0f;

        public Vector2 Scale = Vector2.One;
        public float FloatScale
        {
            set
            {
                Scale = Vector2.One * value;
            }
        }

        public SpriteEffects Flip;

        public Vector2 Offset = Vector2.Zero;

        /// <summary>
        /// Anchor point of the rotation, relative in size to the image
        /// </summary>
        public Vector2 Anchor = Vector2.Zero;

        private float rotation;
        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value - (float)Math.Floor(value / Constants.FullCircle) * Constants.FullCircle;
            }
        }

        /// <summary>
        /// Z-index, or layer depth
        /// </summary>
        public int Z = 0;

        public Sprite(Image image, bool centerize = false)
        {
            Image = image;
            if (centerize)
                Anchor = new Vector2(Image.Texture.Width / 2f, Image.Texture.Height / 2f);
        }

        public override void Render()
        {
            if (Outline.HasValue && OutlineSize > 0f)
            {
                // Iterate every corner (top left, top right, bottom left, bottom right)
                for (int i = -1; i < 2; i+=2)
                {
                    for (int k = -1; k < 2; k += 2)
                    {
                        var offset = new Vector2(i * OutlineSize, k * OutlineSize);
                        Swapper.Instance.Batch.Draw(Image.Texture, Parent.Position + Offset + Anchor * Scale + offset, Image.Clip, Tint, Rotation, Anchor, Scale, Flip, Z);
                    }
                }
            }

            Swapper.Instance.Batch.Draw(Image.Texture, Parent.Position + Offset + Anchor * Scale, Image.Clip, Tint, Rotation, Anchor, Scale, Flip, Z);
        }
    }
}
