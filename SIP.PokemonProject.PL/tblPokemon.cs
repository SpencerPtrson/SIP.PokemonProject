using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblPokemon : IEntity
{
    public Guid Id { get; set; }

    public Guid SpeciesId { get; set; }

    public Guid AbilityId { get; set; }

    public Guid NatureId { get; set; }

    public Guid Type1Id { get; set; }

    public Guid Type2Id { get; set; }

    public Guid? ItemId { get; set; }

    public Guid? MajorStatus { get; set; }

    public bool IsShiny { get; set; }

    public string? Nickname { get; set; }

    public int Level { get; set; }

    public int CurrentHP { get; set; }

    public int HPIVs { get; set; }

    public int AttackIVs { get; set; }

    public int DefenseIVs { get; set; }

    public int SpecialAttackIVs { get; set; }

    public int SpecialDefenseIVs { get; set; }

    public int SpeedIVs { get; set; }

    public int HPEVs { get; set; }

    public int AttackEVs { get; set; }

    public int DefenseEVs { get; set; }

    public int SpecialAttackEVs { get; set; }

    public int SpecialDefenseEVs { get; set; }

    public int SpeedEVs { get; set; }

    public virtual tblSpeciesAbility Ability { get; set; } = null!;

    public virtual tblItem? Item { get; set; }

    public virtual tblNature Nature { get; set; } = null!;

    public virtual tblPokedex Species { get; set; } = null!;

    public virtual tblType Type1 { get; set; } = null!;

    public virtual tblType Type2 { get; set; } = null!;

    public virtual ICollection<tblPokemonTeam> tblPokemonTeams { get; set; } = new List<tblPokemonTeam>();
}
