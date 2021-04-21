using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.Content;
using SwapperV2.World;

namespace SwapperV2.Graphics
{
    public class Line : Component
    {
        public enum LineType
        {
            Horizontal, Vertical
        }

        public Vector2 Offset
        {
            get
            {
                return Sprite.Offset;
            }
            set
            {
                Sprite.Offset = value;
            }
        }

        private void update()
        {
            switch (type)
            {
                case LineType.Vertical:
                    Sprite.Scale = new Vector2(size, length);
                    break;
                default:
                    Sprite.Scale = new Vector2(length, size);
                    break;
            }
        }

        private float size;
        public float Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                update();
            }
        }

        private float length;
        public float Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                update();
            }
        }

        private LineType type;
        public LineType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                update();
            }
        }

        public Sprite Sprite;

        public Line(LineType type, float size, float length, Color? color = null)
        {
            Sprite = new Sprite(Sprites.Dict["pixel"])
            {
                Tint = color ?? Color.Black
            };

            this.type = type;
            this.length = length;
            Size = size;
        }

        public override void Added()
        {
            Parent.Add(Sprite);
        }

        public override void Removed()
        {
            Parent.Remove(Sprite);
        }
    }
}
