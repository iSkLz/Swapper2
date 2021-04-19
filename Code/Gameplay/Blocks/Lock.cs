using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.Graphics;
using SwapperV2.Content;

namespace SwapperV2.Gameplay.Blocks
{
    public class Lock : Block
    {
        public static SpriteSheet Sheet;

        static Lock()
        {
            new SpriteLoader("world/locks", (sheet) =>
            {
                Sheet = new SpriteSheet(sheet, 32);
            });
        }

        public Constants.KeyType Type;
        public Constants.RemoteType RemoteType;
        public Constants.RemoteShape RemoteShape;

        public Sprite Sprite;
        public Sprite Badge;

        public bool Remote => RemoteType != Constants.RemoteType.None;

        public Lock(Constants.KeyType type, Constants.RemoteShape remoteShape, Constants.RemoteType remoteType)
        {
            Type = type;
            RemoteType = remoteType;
            RemoteShape = remoteShape;
        }

        public override void Added()
        {
            Add(Sprite = new Sprite(Sheet.Images[(byte)Type]));

            if (Remote)
                Add(Badge = new Sprite(Tile.Badges.Images[(byte)RemoteShape])
                {
                    Tint = Palette.GetColor(RemoteType)
                });
        }

        public override bool MoveFrom(Tile tile)
        {
            // TODO: Lock logic
            return true;
        }

        public override void MovedFrom(Tile tile)
        {
            // TODO: Lock logic
            switch (Type)
            {
                case Constants.KeyType.Bronze:
                    Level.Player.BronzeKeys--;
                    break;
                case Constants.KeyType.Silver:
                    Level.Player.SilverKeys--;
                    break;
                default:
                    Level.Player.GoldenKeys--;
                    break;
            }

            Tile.Add(Tile.Block = new Block());
            RemoveSelf();
        }

        public override void Removed()
        {
            Sprite.RemoveSelf();
        }
    }
}
