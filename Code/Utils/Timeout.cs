using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.World;

namespace SwapperV2.Utils
{
    public class Timeout : Component
    {
        public event Action End;

        float timer = 0f;

        public Timeout(int frames, Action end) : this(frames / 60f, end) { }

        public Timeout(float duration, Action end)
        {
            timer = duration;
            End += end;
        }

        public override void Update(float delta)
        {
            if (timer > 0f)
            {
                timer -= delta;
            }
            else
            {
                End();
                RemoveSelf();
            }
        }
    }
}
