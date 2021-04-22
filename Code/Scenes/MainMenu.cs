using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.Inputs;
using SwapperV2.Graphics;
using SwapperV2.Scenes;
using SwapperV2.World;
using SwapperV2.Gameplay;
using SwapperV2.Gameplay.Blocks;
using SwapperV2.Tests;
using SwapperV2.Content;

namespace SwapperV2.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu()
        {
            Background = Palette.Void;
            GlobalZoom = 2f;

            Grid grid = new Grid(new Vector2(Swapper.Instance.CenterX, Swapper.Instance.CenterY),
                32, 32, 3, 3, 2f, true);
            Add(grid);
            var tiles = Tile.GenerateTiles(grid, this);
            foreach (var tile in tiles)
            {
                Add(new Test3(tile));
            }
        }
    }
}
