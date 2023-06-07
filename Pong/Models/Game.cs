using System;
using System.Collections.Generic;

namespace Pong.Models;

public partial class Game
{
    public int GameId { get; set; }

    public int Challanger { get; set; }

    public int Opponent { get; set; }

    public int Winner { get; set; }

    public DateTime Date { get; set; }

    public virtual Player ChallangerNavigation { get; set; }

    public virtual Player OpponentNavigation { get; set; }

    public virtual Player WinnerNavigation { get; set; }
}
