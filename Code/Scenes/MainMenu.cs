using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.Inputs;
using SwapperV2.Graphics;
using SwapperV2.Scenes;
using SwapperV2.World;
using SwapperV2.Gameplay;
using SwapperV2.Tests;
using SwapperV2.Content;

namespace SwapperV2.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu()
        {
            Background = Palette.Void;
            var tile = new Tile(Constants.TileColor.Blank, false, new Block());
            tile.Position = new Vector2(Swapper.Instance.CenterX, Swapper.Instance.CenterY);
            Add(tile);
            Add(new Test3(tile));
        }
    }
}
