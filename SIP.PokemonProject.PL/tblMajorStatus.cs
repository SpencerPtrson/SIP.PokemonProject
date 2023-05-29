using System;
using System.Collections.Generic;

namespace SIP.PokemonProject.PL;

public partial class tblMajorStatus
{
    public Guid Id { get; set; }

    public string StatusName { get; set; } = null!;

    public byte[]? StatusIcon { get; set; }
}
