using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblType : IEntity
{
    public Guid Id { get; set; }

    public string TypeName { get; set; } = null!;

    public byte[]? TypeIcon { get; set; }

    public virtual ICollection<tblMove> tblMoves { get; set; } = new List<tblMove>();

    public virtual ICollection<tblPokemon> tblPokemonType1s { get; set; } = new List<tblPokemon>();

    public virtual ICollection<tblPokemon> tblPokemonType2s { get; set; } = new List<tblPokemon>();
}
