﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Turtly.Game.Models
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
