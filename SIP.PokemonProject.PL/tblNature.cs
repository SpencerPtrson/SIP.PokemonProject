using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblNature : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string StatIncreased { get; set; } = null!;

    public string StatDecreased { get; set; } = null!;

    public virtual ICollection<tblPokemon> tblPokemons { get; set; } = new List<tblPokemon>();
}
