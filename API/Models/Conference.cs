using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Conference
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime EventDate { get; set; }

    public DateTime DeadlineDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string Thumbnail { get; set; } = null!;

    public string? File { get; set; }

    public int LocationId { get; set; }

    public int MaxParticipants { get; set; }

    public int? Status { get; set; }

    public int IsPublished { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? CreateUser { get; set; }

    public string? UpdateUser { get; set; }

    public virtual ICollection<ConferenceDelegate> ConferenceDelegates { get; set; } = new List<ConferenceDelegate>();

    public virtual User? CreateUserNavigation { get; set; }

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
