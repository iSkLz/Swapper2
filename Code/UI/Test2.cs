using Microsoft.Xna.Framework;
using SwapperV2.Content;
using SwapperV2.Inputs;
using SwapperV2.Text;
using SwapperV2.World;
using System;
using System.Collections;

namespace SwapperV2.UI
{
    public class Test2 : Entity
    {
        public Label Text;

        public Test2()
        {
            var rect = Swapper.Instance.Window.ClientBounds;
            Position = new Vector2(rect.Width / 2, 100f);
            Add(Text = new Label() {
                Text = "haha custom font sprite\nrenderer goes brrrrrr",
                Size = 0.4f,
                Align = Label.Alignement.Center
            });
        }

        public override bool Update(float delta)
        {
            Text.Color = Color.White;

            // Ah yes sped
            var sped = 40;
            if (Input.Swap.Down) sped *= 3;
            if (Input.Right.Down) Position.X += delta * sped;
            if (Input.Left.Down) Position.X += delta * -sped;
            if (Input.Up.Down) Position.Y += delta * -sped;
            if (Input.Down.Down) Position.Y += delta * sped;

            if (Input.Undo.Pressed) Text.Color = Color.Red;

            return base.Update(delta);
        }
    }
}
