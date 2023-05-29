using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblAbility : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
