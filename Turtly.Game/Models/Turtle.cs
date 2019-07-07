using System;
using System.Collections.Generic;
using System.Text;
using Turtly.Game.Helpers;

namespace Turtly.Game.Models
{
    public class Turtle : Item
    {
        private static Turtle _turtle;
        public Directions Direction { get; set; }

        private Turtle(Point position)
        {
            Position = position;
        }

        public static Turtle Instance(Point position)
        {
            return _turtle ?? (_turtle = new Turtle(position));
        }

        public void Move()
        {
            switch (Direction)
            {
                case Directions.North:
                    ConsoleLogger.Log(_turtle.Position, new Point { X = _turtle.Position.X, Y = _turtle.Position.Y + 1 });
                    _turtle.Position = new Point { X = _turtle.Position.X, Y = _turtle.Position.Y + 1 };
                    break;
                case Directions.South:
                    ConsoleLogger.Log(_turtle.Position, new Point { X = _turtle.Position.X, Y = _turtle.Position.Y - 1 });
                    _turtle.Position = new Point { X = _turtle.Position.X, Y = _turtle.Position.Y - 1 };
                    break;
                case Directions.East:
                    ConsoleLogger.Log(_turtle.Position, new Point { X = _turtle.Position.X + 1, Y = _turtle.Position.Y });
                    _turtle.Position = new Point { X = _turtle.Position.X + 1, Y = _turtle.Position.Y };
                    break;
                case Directions.West:
                    ConsoleLogger.Log(_turtle.Position, new Point { X = _turtle.Position.X - 1, Y = _turtle.Position.Y });
                    _turtle.Position = new Point { X = _turtle.Position.X - 1, Y = _turtle.Position.Y };
                    break;
            }
        }

        public void Rotate(string rotation)
        {
            switch (Direction)
            {
                case Directions.North:
                    if (rotation == "R")
                        Direction = Directions.East;
                    else
                        Direction = Directions.West;
                    ConsoleLogger.Log(Direction);
                    break;
                case Directions.South:
                    if (rotation == "R")
                        Direction = Directions.West;
                    else
                        Direction = Directions.East;
                    ConsoleLogger.Log(Direction);
                    break;
                case Directions.East:
                    if (rotation == "R")
                        Direction = Directions.South;
                    else
                        Direction = Directions.North;
                    ConsoleLogger.Log(Direction);
                    break;
                case Directions.West:
                    if (rotation == "R")
                        Direction = Directions.North;
                    else
                        Direction = Directions.South;

                    ConsoleLogger.Log(Direction);
                    break;
                default:
                    break;
            }
        }
    }
}
