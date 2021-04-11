using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SwapperV2.World;

namespace SwapperV2.Text
{
    public class Label : Component
    {
        public enum Alignement
        {
            Left, Center, Right
        }

        static Font Font => Swapper.Instance.MainFont;

        public Alignement Align;
        public Vector2 Offset;
        public string Text;
        public float Size = 1f;
        public Color Color = Color.White;
        public float Space = 5f;
        public float Line = 10f;

        public override void Render()
        {
            var lines = Text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                var images = Font.GetImages(lines[i]);
                var y = (44 + Line) * i * Size;
                int size = (int)(images.Length * (Font.Width + Space) * Size - Space * Size);

                for (int k = 0; k < images.Length; k++)
                {
                    var pos = Parent.Position + Offset + new Vector2((Font.Width + Space) * k * Size, y);
                    if (Align == Alignement.Right) pos -= new Vector2(size, 0);
                    if (Align == Alignement.Center) pos -= new Vector2(size / 2, 0);
                    Swapper.Instance.Batch.Draw(images[k].Texture, pos, images[k].Clip, Color, 0f, Vector2.Zero, Size, SpriteEffects.None, 0);
                }
            }
        }
    }
}
