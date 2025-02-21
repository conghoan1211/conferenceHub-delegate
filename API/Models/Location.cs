using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? Capacity { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Conference> Conferences { get; set; } = new List<Conference>();
}
