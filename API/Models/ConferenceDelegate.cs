using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ConferenceDelegate
{
    public string Id { get; set; } = null!;

    public string ConferenceId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public int Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Conference Conference { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
