using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using Turtly.Game.Models;
using Turtly.Game.Helpers;


namespace Turtly.Test
{
    public class TurtlyTest
    {
        private Board _board;
        private Watcher _watcher;
        private Turtle _turtle;

        public TurtlyTest()
        {
            _board = new Board(5, 5);
            _watcher = new Watcher(_board);
            _turtle = _board[new Point(0, 0)] as Turtle;

        }

        [Fact]
        public void PointTest()
        {
            Point point = new Game.Models.Point(10, 5);
            Assert.Equal(5, point.Y);
        }

        [Fact]
        public void OutOfBorderTest()
        {
            Assert.Equal(State.OutOfBoard, _watcher.Watch(new Point(-1, 0)));
        }
    }
}
