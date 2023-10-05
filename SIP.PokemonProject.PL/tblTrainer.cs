using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblTrainer : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Money { get; set; }

    public string TrainerClass { get; set; } = null!;

    public virtual ICollection<tblPokemonTeam> tblPokemonTeams { get; set; } = new List<tblPokemonTeam>();
}
