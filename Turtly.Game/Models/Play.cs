using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Turtly.Game.Helpers;

namespace Turtly.Game.Models
{
    public class Play
    {
        private Point _turtleStartPoint;
        private FileReader _fileReader;
        private SettingsModel _settings;
        private Board _board;
        private Watcher _watcher;


        private Play()
        {
            _fileReader = FileReader.Instance();
            _settings = _fileReader.GetSettings();
            _turtleStartPoint = _settings.StartPoint;
            _board = new Board(_settings.Size.Y, _settings.Size.X);
            _watcher = new Watcher(_board);
            Initialize();
        }

        public static Play StartNewGame()
        {
            return new Play();
        }




        public void Start()
        {
            var moves = _settings.Moves;
            var turtle = _board[_turtleStartPoint] as Turtle;
            if (System.Enum.TryParse<Directions>(_settings.Direction, out var dir)) turtle.Direction = dir;
            ConsoleLogger.Log(turtle);
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] != "M") turtle.Rotate(moves[i]);
                else
                {
                    turtle.Move();
                    var situation = _watcher.Watch(turtle.Position);
                    if (situation == State.MineHit)
                    {
                        ConsoleLogger.Log(ConsoleLogger.MineHit);
                        break;
                    }
                    else if (situation == State.Success)
                    {
                        ConsoleLogger.Log(ConsoleLogger.Success);
                        break;
                    }
                    else if (situation == State.StillInDanger)
                    {
                        ConsoleLogger.Log(ConsoleLogger.StillInDanger);
                    }
                    else if (situation == State.OutOfBoard)
                    {
                        ConsoleLogger.Log(ConsoleLogger.Out);
                        break;
                    }
                }
                Thread.Sleep(1200);

            }
            ConsoleLogger.Log(ConsoleLogger.Over);
        }

        private void Initialize()
        {
            SetTurtle(_turtleStartPoint);
            SetExit(_settings.SuccessPoint);
            SetMines(_settings.MinePoints);
        }



        private void SetMines(List<Point> mines)
        {
            foreach (var minePosition in mines)
            {
                try
                {
                    _board[minePosition] = new Mine() { Position = minePosition };
                }
                catch
                { }
            }
        }

        private void SetExit(Point exitPosition)
        {
            try
            {
                _board[exitPosition] = new Success() { Position = exitPosition };
            }
            catch
            { }
        }


        private void SetTurtle(Point turtlePosition)
        {
            try
            {
                _board[turtlePosition] = Turtle.Instance(turtlePosition);
            }
            catch
            { }
        }
    }
}
