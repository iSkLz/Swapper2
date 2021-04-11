using System;
using System.Collections.Generic;
using SwapperV2.World;

namespace SwapperV2.Graphics
{
    public class Animation : Sprite
    {
        public SpriteSheet Sheet { get; }
        public int FrameLength;
        public bool Loop;

        public Image Current => Sheet.Sprites[index];

        private int progress = 0;
        private int index = 0;

        /// <summary>
        /// Creates an animation
        /// </summary>
        /// <param name="frameLength">Length of each animation frame in game frames</param>
        /// <param name="loop"></param>
        public Animation(SpriteSheet sheet, int frameLength, bool loop) : base(sheet.Sprites[0])
        {
            Sheet = sheet;
            FrameLength = frameLength;
            Loop = loop;
        }

        public override bool Update(float delta)
        {
            progress++;

            if (progress == FrameLength)
            {
                if (Loop) index = (index + 1) % Sheet.Sprites.Length;
                else if (index != Sheet.Sprites.Length) index++;
                progress = 0;
            }

            Image = Current;

            return false;
        }
    }
}
