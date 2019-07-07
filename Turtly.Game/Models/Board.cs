using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Turtly.Game.Models
{
    public class Board
    {
        private Item[][] _points;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Board(int x, int y)
        {
            Width = y;
            Height = x;

            _points = new Item[x][];
            for (int i = 0; i < x; i++)
            {
                _points[i] = new Item[y];
                for (int j = 0; j < y; j++)
                {
                    _points[i][j] = new Item() { Position = new Point { X = i, Y = j } };
                }
            }
        }
        public Item this[int index1, int index2]
        {
            get { return _points[index1][index2]; }
            set { _points[index1][index2] = value; }
        }

        public Item this[Point p]
        {
            get { return _points[p.X][p.Y]; }
            set { _points[p.X][p.Y] = value; }
        }
    }
}
