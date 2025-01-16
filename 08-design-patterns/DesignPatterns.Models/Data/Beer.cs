using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Data;

public partial class Beer
{
    public int BeerId { get; set; }

    public string Name { get; set; } = null!;

    public string Style { get; set; } = null!;

    public Guid BrandId { get; set; }
}
