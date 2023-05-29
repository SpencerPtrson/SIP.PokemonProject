using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<tblPokemon> tblPokemons { get; set; } = new List<tblPokemon>();
}
