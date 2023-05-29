using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblAddedAffect
{
    public Guid Id { get; set; }

    public Guid MoveId { get; set; }

    public string Effect { get; set; } = null!;

    public int Chance { get; set; }
}
