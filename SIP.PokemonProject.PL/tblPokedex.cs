using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblPokedex : IEntity
{
    public Guid Id { get; set; }

    public int PokedexNum { get; set; }

    public string SpeciesName { get; set; } = null!;

    public Guid Type1Id { get; set; }

    public Guid Type2Id { get; set; }

    public int BaseHP { get; set; }

    public int BaseAttack { get; set; }

    public int BaseDefense { get; set; }

    public int BaseSpecialAttack { get; set; }

    public int BaseSpecialDefense { get; set; }

    public int BaseSpeed { get; set; }

    public string SpriteName { get; set; } = null!;

    public virtual ICollection<tblPokemon> tblPokemons { get; set; } = new List<tblPokemon>();
}
