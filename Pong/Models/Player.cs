using System;
using System.Collections.Generic;

namespace Pong.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? Name { get; set; }

    public int Score { get; set; }
}
