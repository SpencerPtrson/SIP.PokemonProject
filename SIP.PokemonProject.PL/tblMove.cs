using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblMove : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid TypeId { get; set; }

    public string Category { get; set; } = null!;

    public int PP { get; set; }

    public int? Power { get; set; }

    public int? Accuracy { get; set; }

    public int Priority { get; set; }

    public string Target { get; set; } = null!;

    public double CritRate { get; set; }

    public string Description { get; set; } = null!;

    public virtual tblType Type { get; set; } = null!;
}
