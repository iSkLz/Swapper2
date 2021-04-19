using System;
using System.Collections.Generic;

using SwapperV2.World;
using SwapperV2.Graphics;
using SwapperV2.Scenes;

namespace SwapperV2.Gameplay
{
    public class Block : Component
    {
        public Level Level => (Level)Parent.Scene;
        public Tile Tile => (Tile)Parent;

        public virtual bool MoveFrom(Tile tile) => true;
        public virtual bool MoveTo(Tile tile) => true;

        public virtual void MovedFrom(Tile tile) { }
        public virtual void MovedTo(Tile tile) { }
    }
}
