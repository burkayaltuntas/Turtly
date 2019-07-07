using System;
using System.Threading;
using Turtly.Game;

namespace Turtly
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = Game.Models.Play.StartNewGame();
            game.Start();

            System.Console.ReadKey();
        }
    }
}
