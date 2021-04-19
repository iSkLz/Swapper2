using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.World;

namespace SwapperV2.Utils
{
    public class Progress : Component
    {
        public float Value;

        private Action<float> update;
        private float timer = 0f;

        /// <summary>
        /// Creates a progressor using a function <paramref name="func"/> (x -> y).
        /// The function is fed a number between <paramref name="inputMin"/> and <paramref name="inputMax"/>.
        /// The output value will be between <paramref name="outputMin"/> and <paramref name="outputMax"/>
        /// </summary>
        /// <param name="func">The function to use</param>
        /// <param name="inputMin">The starting x value</param>
        /// <param name="inputMax">The ending x value</param>
        /// <param name="outputMin">The starting output value</param>
        /// <param name="outputMax">The ending output value</param>
        public Progress(Func<float, float> func, float time,
            float inputMin, float inputMax, float outputMin = 0f, float outputMax = 1f)
        {
            var inputScalar = inputMax - inputMin;
            var outputScalar = outputMax - outputMin;

            update = (delta) =>
            {
                var progress = timer / time;

                if (progress > 1f)
                {
                    Enabled = false;
                    return;
                }

                var x = progress * inputScalar + inputMin;
                Value = func(x) * outputScalar + outputMin;

                timer += delta;
            };
        }

        // TODO: Progressive functions

        public override void Update(float delta)
        {
            update(delta);
        }
    }
}
