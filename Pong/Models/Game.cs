using System;
using System.Collections.Generic;

namespace Pong.Models;

public partial class Game
{
    public DateTime Date { get; set; }

    public int Challanger { get; set; }

    public int Opponent { get; set; }

    public int Winner { get; set; }
}
