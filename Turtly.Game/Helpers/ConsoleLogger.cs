using System;
using System.Collections.Generic;
using System.Text;
using Turtly.Game.Models;

namespace Turtly.Game.Helpers
{
    public class ConsoleLogger
    {
        public static string startString = "Starting Position of Turtle: ({x},{y}), Direction: {dir}";
        public static string movedFromTo = "Turtle moved from position {from} to {to}";
        public static string rotate = "Turned to {to}";
        public const string MineHit = "RIP Turtly :(";
        public const string Out = "Turtly went out of board";
        public const string StillInDanger = "Still in danger!";
        public const string Success = "Turtly Survived!";
        public const string Over = "Moves are over, so game also!";


        public static void Log(Point pointFrom, Point pointTo)
        {
            var combinePointFrom = $"({pointFrom.X},{pointFrom.Y})";
            var combinePointTo = $"({pointTo.X},{pointTo.Y})";
            var printText = movedFromTo.Replace("{from}", combinePointFrom).Replace("{to}", combinePointTo);

            Console.WriteLine(printText);
            Console.WriteLine(new string('-', 30));
        }

        public static void Log(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 30));
        }
        public static void Log(Directions dir)
        {
            Console.WriteLine(rotate.Replace("{to}", dir.ToString()));
            Console.WriteLine(new string('-', 30));
        }

        public static void Log(Turtle turtle)
        {
            Console.WriteLine(startString.Replace("{x}", turtle.Position.X.ToString()).Replace("{y}", turtle.Position.Y.ToString()).Replace("{dir}", turtle.Direction.ToString()));
            Console.WriteLine(new string('-', 30));
        }

    }
}
