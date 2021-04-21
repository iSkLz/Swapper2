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

            Entity entity = new Entity()
            {
                Position = new Vector2(Swapper.Instance.CenterX, Swapper.Instance.CenterY)
            };
            var width = 2f;
            entity.Add(new Line(Line.LineType.Horizontal, width, 100f, Color.Red));
            entity.Add(new Line(Line.LineType.Horizontal, width, -100f, Color.Green));
            entity.Add(new Line(Line.LineType.Vertical, width, 100f, Color.Blue));
            entity.Add(new Line(Line.LineType.Vertical, width, -100f, Color.Purple));
            Add(entity);
        }
    }
}
