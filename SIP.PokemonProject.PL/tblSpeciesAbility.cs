using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblSpeciesAbility
{
    public Guid Id { get; set; }

    public Guid PokedexId { get; set; }

    public Guid AbilityId { get; set; }

    public int AbilityNum { get; set; }

    public virtual ICollection<tblPokemon> tblPokemons { get; set; } = new List<tblPokemon>();
}
