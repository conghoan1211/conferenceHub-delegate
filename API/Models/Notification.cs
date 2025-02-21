using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Notification
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string ConferenceId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Conference Conference { get; set; } = null!;
}
