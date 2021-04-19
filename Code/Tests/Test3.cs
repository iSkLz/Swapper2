using System;
using System.Collections;

using SwapperV2.Graphics;
using SwapperV2.Scenes;
using SwapperV2.World;
using SwapperV2.Gameplay;
using SwapperV2.Utils;
using SwapperV2.Content;

namespace SwapperV2.Tests
{
    public class Test3 : Entity
    {
        // 2 true bits
        const byte keyTypeMask = (1 << 2) - 1;

        // 2 true bits and 2 false bits
        const byte remoteShapeShift = 2;
        const byte remoteShapeMask = ((1 << 2) - 1) << remoteShapeShift;

        // 3 true bits
        const byte remoteTypeShift = 4;
        const byte remoteTypeMask = ((1 << 4) - 1) << remoteTypeShift;

        public Test3(Tile tile)
        {
            Add(new Routine(Play(tile)));
        }

        public IEnumerator Play(Tile entity)
        {
            Random ay = new Random();

            while (true)
            {
                yield return 0.5f;
                entity.Remove(entity.Block);

                /*
                int x1 = ay.Next(3), x2 = (ay.Next(4) << 2), x3 = (ay.Next(8) << 4);
                byte blockNum = (byte)(x1 | x2 | x3);//*/

                ///*
                byte blockNum = (byte)(ay.Next(3) | (ay.Next(4) << 2) | (ay.Next(5) << 4));
                //*/

                var keyType = blockNum & keyTypeMask;
                var shape = (blockNum & remoteShapeMask) >> remoteShapeShift;

                var tile = new Map.Tile()
                {
                    Block = Map.BlockType.Key,
                    Type = Map.TileType.Blank
                };

                if (shape != (byte)Constants.RemoteShape.None)
                    tile.Data = new object[]
                    {
                        keyType, shape, (blockNum & remoteTypeMask) >> remoteTypeShift
                    };
                else
                    tile.Data = new object[]
                    {
                        keyType, shape, (int)Constants.RemoteType.None
                    };

                entity.Add(entity.Block = tile.GetBlock());
            }
        }
    }
}
