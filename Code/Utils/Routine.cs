using System;
using System.Collections;
using System.Collections.Generic;

using SwapperV2.Graphics;
using SwapperV2.Scenes;
using SwapperV2.World;

namespace SwapperV2.Utils
{
    public class Routine : Component
    {
        private readonly Stack<IEnumerator> Enumerators = new Stack<IEnumerator>();
        private IEnumerator Active;
        private float Timer = 0f;

        public Routine(IEnumerator call)
        {
            Active = call;
        }

        public override bool Update(float delta)
        {
            if (Timer > 0)
            {
                Timer -= delta;
                return false;
            }

            if (Active.MoveNext())
            {
                var val = Active.Current;

                if (val is float timer)
                {
                    Timer = timer;
                }
                else if (val is int frames)
                {
                    Timer = frames / 60f;
                }
                else if (val is IEnumerator routine)
                {
                    Enumerators.Push(Active);
                    Active = routine;
                }

                // If the value is something else one frame will be skipped
            }
            else if (Enumerators.Count == 0)
            {
                return true;
            }
            else
            {
                Active = Enumerators.Pop();
            }

            return false;
        }
    }
}
