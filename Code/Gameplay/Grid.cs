using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using SwapperV2.Graphics;
using SwapperV2.World;

namespace SwapperV2.Gameplay
{
    public class Grid : Entity
    {
        public Line[] HorizontalLines;
        public Line[] VerticalLines;

        /// <summary>
        /// Full width of the grid including inner lines
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// Full height of the grid including inner lines
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// Full width of the grid including outer and inner lines
        /// </summary>
        public float OutlinedWidth { get; }

        /// <summary>
        /// Full height of the grid including outer and inner lines
        /// </summary>
        public float OutlinedHeight { get; }

        /// <summary>
        /// Width of one cell
        /// </summary>
        public float CellWidth { get; }

        /// <summary>
        /// Height of one cell
        /// </summary>
        public float CellHeight { get; }

        /// <summary>
        /// Number of cells on one row
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Number of cells on one column
        /// </summary>
        public int Rows { get; }

        public float LineSize { get; }

        /// <summary>
        /// Width of one cell and the line before it
        /// </summary>
        public float GridCellWidth { get; }

        /// <summary>
        /// Height of one cell and the line before it
        /// </summary>
        public float GridCellHeight { get; }

        private bool center;

        public Grid(Vector2 position, float cellWidth, float cellHeight, int columns, int rows, float lineSize, bool center = false)
        {
            Position = position;
            HorizontalLines = new Line[columns + 1];
            VerticalLines = new Line[rows + 1];

            CellWidth = cellWidth;
            CellHeight = cellHeight;
            Columns = columns;
            Rows = rows;
            LineSize = lineSize;

            GridCellWidth = CellWidth + LineSize;
            GridCellHeight = CellHeight + LineSize;

            OutlinedWidth = CellWidth * Columns + VerticalLines.Length * LineSize;
            OutlinedHeight = CellHeight * Rows + HorizontalLines.Length * LineSize;

            Width = OutlinedWidth - 2 * LineSize;
            Height = OutlinedHeight - 2 * LineSize;

            this.center = center;

            for (int i = 0; i <= columns; i++)
            {
                var pos = GridCellWidth * i - LineSize;
                Add(VerticalLines[i] = new Line(Line.LineType.Vertical, LineSize, OutlinedHeight)
                {
                    Offset = new Vector2(pos, -LineSize)
                });
            }

            for (int i = 0; i <= rows; i++)
            {
                var pos = GridCellHeight * i - LineSize;
                Add(HorizontalLines[i] = new Line(Line.LineType.Horizontal, LineSize, OutlinedWidth)
                {
                    Offset = new Vector2(-LineSize, pos)
                });
            }
        }

        public override void Added()
        {
            if (center) Position -= new Vector2(OutlinedWidth / 2f, OutlinedHeight / 2f) * Scene.GlobalZoom;
        }

        public Vector2 GetPosition(int x, int y)
        {
            return new Vector2(x * GridCellWidth, y * GridCellHeight) * Scene.GlobalZoom + Position;
        }
    }
}
