using System;
using System.Collections.Generic;
using System.Text;

namespace Turtly.Game.Models
{
    public enum Directions
    {
        North,
        South,
        East,
        West
    }

    public enum State
    {
        Success,
        MineHit,
        StillInDanger,
        OutOfBoard
    }
}
