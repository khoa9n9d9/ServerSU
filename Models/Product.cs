using System;
using System.Collections.Generic;

namespace SUServer.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public short Type { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Content { get; set; }

    public string? Image1 { get; set; }

    public string? Image2 { get; set; }

    public string? Image3 { get; set; }

    public string? Sizes { get; set; }

    public string? Colors { get; set; }

    public string? Url { get; set; }

    public decimal? Price { get; set; }
}
