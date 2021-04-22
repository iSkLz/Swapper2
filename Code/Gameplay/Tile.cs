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

        public static Tile[,] GenerateTiles(Grid grid, Scene scene)
        {
            var tiles = new Tile[grid.Columns, grid.Rows];

            for (int x = 0; x < grid.Columns; x++)
            {
                for (int y = 0; y < grid.Rows; y++)
                {
                    scene.Add(tiles[x, y] = new Tile(Constants.TileColor.Blank, false, new Block())
                    {
                        Position = grid.GetPosition(x, y)
                    });
                }
            }

            return tiles;
        }

        public Level Level => (Level)Scene;

        public Animation Sprite;
        public Sprite Lock;
        public Sprite Badge;

        public Constants.TileColor Type;
        public bool Locked;

        private Block block;
        public Block Block
        {
            get
            {
                return block;
            }
            set
            {
                //if (value.GetType() == typeof(Blocks.Key)) System.Diagnostics.Debugger.Break();
                block?.RemoveSelf();
                Add(block = value);
            }
        }

        public bool Interactable => Type >= Constants.TileColor.Void;
        public bool Colored => Type <= Constants.TileColor.Blue;

        public Tile(Constants.TileColor color, bool locked, Block block)
        {
            Lock = new Sprite(Sprites.Dict["world/tile/lockedwhite"]);
            Type = color;
            Locked = locked;
            Block = block;
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

        public void MovedFrom(Tile tile)
        {
            Block.MovedFrom(tile);
        }

        public void MovedTo(Tile tile)
        {
            Locked = true;
            Block.MovedTo(tile);
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

        public override void Update(float delta)
        {
            // TODO: Debug the STUPID key components accumulation
            if (Components.Count > 2) System.Diagnostics.Debugger.Break();
            base.Update(delta);
        }
    }
}
