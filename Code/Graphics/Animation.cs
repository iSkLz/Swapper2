using System;
using System.Collections;

using SwapperV2.World;

namespace SwapperV2.Graphics
{
    public class Animation : Sprite
    {
        public event Action End;

        public SpriteSheet Sheet { get; }
        public int FrameLength;
        public bool Loop;

        public Image Current => Sheet.Images[Index];
        public int Index = 0;

        public bool Finished;

        private int progress = 0;

        /// <summary>
        /// Creates an animation
        /// </summary>
        /// <param name="frameLength">Length of each animation frame in game frames</param>
        /// <param name="loop"></param>
        public Animation(SpriteSheet sheet, int frameLength, bool loop, int start = 0) : base(sheet.Images[0])
        {
            Sheet = sheet;
            FrameLength = frameLength;
            Loop = loop;
            if (start == -1)
                Index = Sheet.Images.Length - 1;
            else
                Index = start;

            Image = Current;
        }

        public override void Update(float delta)
        {
            if (!Loop && Index == Sheet.Images.Length - 1)
            {
                if (Finished)
                    return;
                else
                {
                    Finished = true;
                    End?.Invoke();
                    return;
                }
            }

            Finished = false;
            progress++;

            if (progress == FrameLength)
            {
                Index = (Index + 1) % Sheet.Images.Length;
                progress = 0;
            }

            Image = Current;
        }
    }
}
