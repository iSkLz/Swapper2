using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.World;
using SwapperV2.Content;
using SwapperV2.Gameplay;

namespace SwapperV2.Scenes
{
    public class MapEditor : Scene
    {
        public Map Map;
        public Vector2 TilesPosition;

        public MapEditor()
        {
            Map = new Map();

            for (int x = 0; x < Map.Width; x++)
            {
                for (int y = 0; y < Map.Height; y++)
                {
                    Add(new EditTile(x, y, Map.Tiles[x, y]));
                }
            }
        }
    }
}
