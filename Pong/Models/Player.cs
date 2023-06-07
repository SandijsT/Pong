using System;
using System.Collections.Generic;

namespace Pong.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string Name { get; set; }

    public int Score { get; set; }

    public virtual ICollection<Game> GameChallangerNavigations { get; set; } = new List<Game>();

    public virtual ICollection<Game> GameOpponentNavigations { get; set; } = new List<Game>();

    public virtual ICollection<Game> GameWinnerNavigations { get; set; } = new List<Game>();
}
