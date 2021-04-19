using Microsoft.Xna.Framework;
using SwapperV2.Content;
using SwapperV2.Graphics;
using SwapperV2.Utils;
using SwapperV2.World;
using System;
using System.Collections;

namespace SwapperV2.Tests
{
    public class Test : Entity
    {
        public Random Randomizer = new Random();
        public Sprite Sprite;

        public Test()
        {
            Position = new Vector2(200f);
            Add(Sprite = new Sprite(Sprites.Dict["pixel"], true) {
                Scale = new Vector2(100, 100)
            });
            Add(new Routine(UpdateSprite()));
        }

        public IEnumerator UpdateSprite()
        {
            while (true)
            {
                Sprite.Tint = new Color(Randomizer.Next(256), Randomizer.Next(256), Randomizer.Next(256));
                yield return 0.5f;
            }
        }

        public override void Update(float delta)
        {
            Sprite.Rotation += Constants.FullCircle * delta;
            base.Update(delta);
        }
    }
}
