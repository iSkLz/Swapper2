using System;
using System.Collections.Generic;

using SwapperV2.Graphics;

namespace SwapperV2.Content
{
    public class SpriteLoader
    {
        // This list both keeps track of loaders and keeps them alive (garbage collection)
        public static List<SpriteLoader> Loaders = new List<SpriteLoader>();

        public string Path;
        public Action<Image> Load;

        public SpriteLoader(string path, Action<Image> load)
        {
            Path = path;
            Load = load;

            if (Sprites.Loaded)
                Resolve();
            else
                Loaders.Add(this);
        }

        public void Resolve()
        {
            Load(Sprites.Dict[Path]);
        }
    }
}
