using System;
using System.Collections.Generic;
using System.IO;

using SwapperV2.Gameplay;
using SwapperV2.Gameplay.Blocks;

namespace SwapperV2.Content
{
    public class Map
    {
        #region Bit Masks
        // 5 true bits
        const ushort widthMask = (1 << 5) - 1;

        // 5 true bits and 5 false bits
        const ushort heightMask = ((1 << 5) - 1) << 5;

        // 4 true bits and 10 false bits
        const ushort swapsMask = ((1 << 4) - 1) << 10;

        // 3 true bits
        const byte tileNumMask = (1 << 3) - 1;

        // 5 true bits and 3 false bits
        const byte blockNumMask = ((1 << 5) - 1) << 3;

        // 2 true bits
        const byte keyTypeMask = (1 << 2) - 1;

        // 2 true bits and 2 false bits
        const byte remoteShapeMask = ((1 << 2) - 1) << 2;

        // 3 true bits
        const byte remoteTypeMask = ((1 << 4) - 1) << 4;
        #endregion

        #region Tile Class
        public enum TileType
        {
            RedLocked, BlueLocked, Red, Blue, Blank, Void, Purple
        }

        public enum BlockType
        {
            Pass, Key, Lock, Counter, Push, None
        }

        // A struct would be more appropriate but we need to use a class for references
        public class Tile
        {
            public TileType Type;
            public BlockType Block;
            public object[] Data;

            public bool Locked => Type <= TileType.BlueLocked;
            public Constants.TileColor Color => (Constants.TileColor)
            (
                (Type >= TileType.Red)
                ? Type - TileType.Red
                : (int)Type
            );

            public Block GetBlock()
            {
                switch (Block)
                {
                    case BlockType.Key:
                        return new Key(
                            (Constants.KeyType)(int)(Data[0]),
                            (Constants.RemoteShape)(int)(Data[1]),
                            (Constants.RemoteType)(int)(Data[2])
                        );
                    case BlockType.Lock:
                        return new Key((Constants.KeyType)Data[0],
                            (Constants.RemoteShape)Data[1],
                            (Constants.RemoteType)Data[2]);
                    default:
                        return new Block();
                }
            }
        }
        #endregion

        public Tile[,] Tiles;
        public int Width;
        public int Height;
        public int Swaps;

        public Map()
        {
            Width = 30;
            Height = 20;
            Swaps = 0;

            Tiles = new Tile[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Tiles[x, y] = new Tile()
                    {
                        Type = TileType.Blank,
                        Block = BlockType.None
                    };
                }
            }
        }

        public void Load(BinaryReader reader)
        {
            var mapConst = reader.ReadUInt16();
            Width = mapConst & widthMask;
            Height = mapConst & heightMask;
            Swaps = mapConst & swapsMask;

            Tiles = new Tile[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var tileNum = reader.ReadByte();
                    var type = (TileType)(tileNum & tileNumMask);

                    var tile = new Tile()
                    {
                        Type = type
                    };

                    if (type != TileType.Void && type != TileType.Purple)
                    {
                        switch (tile.Block = (BlockType)(tileNum & blockNumMask))
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
                                byte blockNum = reader.ReadByte();
                                var keyType = blockNum & keyTypeMask;
                                var shape = blockNum & remoteShapeMask;

                                if (shape != (byte)Constants.RemoteShape.None)
                                    tile.Data = new object[]
                                    {
                                        keyType, shape, blockNum & remoteTypeMask
                                    };
                                else
                                    tile.Data = new object[]
                                    {
                                        keyType, shape, (int)Constants.RemoteType.None
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
