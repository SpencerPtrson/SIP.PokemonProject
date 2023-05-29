using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblPokemonTeam
{
    public Guid Id { get; set; }

    public Guid TrainerId { get; set; }

    public Guid PokemonId { get; set; }

    public virtual tblPokemon Pokemon { get; set; } = null!;

    public virtual tblTrainer Trainer { get; set; } = null!;
}
