using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using SwapperV2.World;
using SwapperV2.Inputs;

namespace SwapperV2.UI
{
    public class MouseListener : Component
    {
        public Vector2 Size;
        public Vector2 End => Parent.Position + Size;

        public event Action Left;
        public event Action Middle;
        public event Action Right;
        public event Action<int> Scroll;

        public MouseListener(Vector2 size)
        {
            Size = size;
        }

        public override void Update(float delta)
        {
            if (Hover() && Collector.Pressed(Collector.MouseButton.Left)) Left?.Invoke();
            if (Hover() && Collector.Pressed(Collector.MouseButton.Middle)) Middle?.Invoke();
            if (Hover() && Collector.Pressed(Collector.MouseButton.Right)) Right?.Invoke();

            if (Hover() && Collector.Wheel() != 0) Scroll?.Invoke(Collector.Wheel());
        }

        public bool Hover()
        {
            var cur = Collector.Cursor();
            var pos = Parent.Position;
            var end = End;

            return cur.X > pos.X && cur.Y > pos.Y && end.X > cur.X && end.Y > cur.Y;
        }

        public bool Down(Collector.MouseButton button)
        {
            return Hover() && Collector.Down(button);
        }

        public bool Up(Collector.MouseButton button)
        {
            return Hover() && Collector.Up(button);
        }
    }
}
