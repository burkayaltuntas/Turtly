using System;
using System.Collections.Generic;
using System.Text;

namespace Turtly.Game.Models
{
    public class SettingsModel
    {
        public Point Size { get; set; }
        public Point StartPoint { get; set; }
        public Point SuccessPoint { get; set; }
        public List<Point> MinePoints { get; set; } = new List<Point>();
        public string Direction { get; set; }
        public string[] Moves { get; set; }
    }
}
