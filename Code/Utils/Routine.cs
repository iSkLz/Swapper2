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
        public static IEnumerator Loop(IEnumerator routine)
        {
            while (true)
            {
                yield return routine;
            }
        }

        public event Action End;

        private readonly Stack<IEnumerator> Enumerators = new Stack<IEnumerator>();
        // Using Stack.Peek instead of a separate variable implies additional checks and lookup time
        private IEnumerator Active;
        private float Timer = 0f;

        public bool Finished { get; private set; }

        public Routine(IEnumerator call, bool removeOnEnd = false, bool loop = false)
        {
            if (loop)
            {
                Active = Loop(call);
            }

            Active = call;
            if (removeOnEnd) End += () =>
            {
                RemoveSelf();
            };
        }

        public override void Update(float delta)
        {
            if (Timer > 0)
            {
                Timer -= delta;
                return;
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
                if (!Finished)
                {
                    Finished = true;
                    End?.Invoke();
                }
                return;
            }
            else
            {
                Active = Enumerators.Pop();
            }
        }
    }
}
