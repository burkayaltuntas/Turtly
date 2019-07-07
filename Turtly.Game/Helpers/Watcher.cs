using System;
using System.Collections.Generic;
using System.Text;
using Turtly.Game.Models;
using System.Linq;


namespace Turtly.Game.Helpers
{
    public class Watcher
    {
        private int _width;
        private int _height;
        private Board _board;

        public Watcher(Board board)
        {
            _width = board.Width;
            _height = board.Height;
            _board = board;
        }

        public State Watch(Point position)
        {
            if (IsOutOfBounds(position)) return State.OutOfBoard;
            else if (IsSuccess(position)) return State.Success;
            else if (IsMineHit(position)) return State.MineHit;
            else return State.StillInDanger;
        }


        private bool IsMineHit(Point position)
        {
            return _board[position] is Mine;
        }

        private bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.X >= _height || position.Y < 0 || position.Y >= _width;
        }

        private bool IsSuccess(Point position)
        {
            return _board[position] is Success;
        }

    }
}
