using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.World;
using SwapperV2.Scenes;
using SwapperV2.Content;

namespace SwapperV2.Gameplay
{
    public class EditTile : Entity
    {
        public Map.Tile Tile;
        public Tile Entity;
        public int X, Y;

        public EditTile(int x, int y, Map.Tile tile)
        {
            X = x;
            Y = y;
            Tile = tile;
            Entity = new Tile(tile.Color, tile.Locked, tile.GetBlock());
        }

        public override void Added()
        {
            Position = ((MapEditor)Scene).TilesPosition + new Vector2(X, Y) * 32;
        }
    }
}
