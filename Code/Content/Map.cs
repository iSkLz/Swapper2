using System;
using System.Collections.Generic;
using System.IO;

namespace SwapperV2.Content
{
    public class Map
    {
        // 5 true bits
        const ushort widthConst = 0x1f;

        // 5 true bits and 5 false bits
        const ushort heightConst = 0x1f << 5;

        // 4 true bits and 10 false bits
        const ushort swapsConst = 0xf << 10;

        // 3 true bits
        const byte tileConst = 0x7;

        // 5 true bits and 3 false bits
        const byte blockConst = 0x1f << 3;

        // 3 true bits
        const byte remotekeyConst = 0x3;

        // 3 true bits and 3 false bits
        const byte keytypeConst = 0x3 << 2;

        public enum TileType
        {
            RedLocked, BlueLocked, Red, Blue, Blank, Purple, Void
        }

        public enum BlockType
        {
            Pass, Key, Lock, Counter, Push
        }

        public struct Tile
        {
            public TileType Type;
            public BlockType Block;
            public object[] Data;
        }

        public Tile[,] Tiles;
        public int Width;
        public int Height;
        public int Swaps;

        public Map(BinaryReader reader)
        {
            var mapConst = reader.ReadUInt16();
            Width = mapConst & widthConst;
            Height = mapConst & heightConst;
            Swaps = mapConst & swapsConst;

            Tiles = new Tile[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var tileNum = reader.ReadByte();
                    var type = (TileType)(tileNum & tileConst);

                    var tile = new Tile()
                    {
                        Type = type
                    };

                    if (type != TileType.Void && type != TileType.Purple)
                    {
                        switch (tile.Block = (BlockType)(tileNum & blockConst))
                        {
                            case BlockType.Pass:
                            case BlockType.Push:
                                tile.Data = new object[]
                                {
                                    (Constants.Direction)reader.ReadUInt16()
                                };
                                break;
                            case BlockType.Key:
                            case BlockType.Lock:
                                var blockNum = reader.ReadByte();
                                tile.Data = new object[]
                                {
                                    (Constants.KeyType)(blockNum & keytypeConst),
                                    (Constants.RemoteType)(blockNum & remotekeyConst)
                                };
                                break;
                            case BlockType.Counter:
                                tile.Data = new object[]
                                {
                                    reader.ReadByte()
                                };
                                break;
                        }
                    }
                }
            }
        }
    }
}
