using System;
using System.Collections.Generic;

using SwapperV2.Graphics;
using SwapperV2.Scenes;
using SwapperV2.World;

namespace SwapperV2.Utils
{
    public class Transition : Entity
    {
        public bool Out { get; }

        public Transition(bool goingGut)
        {
            Out = goingGut;
        }
    }
}
