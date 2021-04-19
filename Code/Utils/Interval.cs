using System;
using System.Collections;
using System.Collections.Generic;

using SwapperV2.World;

namespace SwapperV2.Utils
{
    public class Interval : Component
    {
        public event Action Tick;
        public float Delay;

        private float timer;

        public Interval(int frames) : this(frames / 60f) { }

        public Interval(float delay)
        {
            Delay = delay;
        }

        public override void Update(float delta)
        {
            if (timer > 0f)
                timer -= delta;
            else
                Tick.Invoke();
        }
    }
}
