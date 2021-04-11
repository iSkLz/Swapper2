using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SwapperV2.Graphics;

namespace SwapperV2.Content
{
    public static class Sprites
    {
        public static Dictionary<string, Image> Dict = new Dictionary<string, Image>();

        public static void Load()
        {
            ScanDir("Sprites");
        }

        private static void ScanDir(string path)
        {
            var scanDir = new DirectoryInfo(path);

            foreach (var dir in scanDir.EnumerateDirectories())
            {
                ScanDir(path + "/" + dir.Name);
            }

            foreach (var file in scanDir.EnumerateFiles("*.png"))
            {
                using (Stream stream = new FileStream(file.FullName, FileMode.Open))
                {
                    var ID = (path + "/" + file.Name);
                    ID = ID.Substring(8, ID.Length - 12).ToLower();
                    Dict.Add(ID, new Image(Texture2D.FromStream(Swapper.Instance.GraphicsDevice, stream)));
                }
            }
        }
    }
}
