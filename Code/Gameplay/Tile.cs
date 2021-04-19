using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.World;
using SwapperV2.Graphics;
using SwapperV2.Scenes;
using SwapperV2.Content;

namespace SwapperV2.Gameplay
{
    public class Tile : Entity
    {
        public static SpriteSheet Badges;

        static Tile()
        {
            new SpriteLoader("world/badges", (sheet) =>
            {
                Badges = new SpriteSheet(sheet, 32);
            });
        }

        public Level Level => (Level)Scene;

        public Animation Sprite;
        public Sprite Lock;
        public Sprite Badge;

        public Constants.TileColor Type;
        public bool Locked;
        public Block Block;

        public bool Interactable => Type >= Constants.TileColor.Void;
        public bool Colored => Type <= Constants.TileColor.Blue;

        public Tile(Constants.TileColor color, bool locked, Block block)
        {
            Lock = new Sprite(Sprites.Dict["world/tile/lockedwhite"]);
            Type = color;
            Locked = locked;
            Add(Block = block);
            AddSprite();
        }

        public void AddSprite(int start = -1)
        {
            Add(Sprite = new Animation(
                new SpriteSheet(Sprites.Dict["world/tile/filled"], 32),
                3, false, start)
            );
            Sprite.Tint = Palette.GetColor(Type);
        }

        public bool MoveFrom(Tile tile)
        {
            return Type != Constants.TileColor.Void && Block.MoveFrom(tile);
        }

        public bool MoveTo(Tile tile)
        {
            return Block.MoveTo(tile);
        }

        public void MovedFrom()
        {

        }

        public void MovedTo()
        {
            Locked = true;
        }

        public void Paint(Constants.TileColor color)
        {
            var sprite = Sprite;
            Type = color;
            AddSprite(0);

            Sprite.End += () =>
            {
                if (sprite.Finished)
                    sprite.RemoveSelf();
                else sprite.End += () =>
                {
                    sprite.RemoveSelf();
                };
            };
        }

        public override void Render()
        {
            if (Lock.Enabled = Locked)
            {
                Lock.Tint = Colored ? Color.White : Palette.Object;
            }

            base.Render();
        }
    }
}
