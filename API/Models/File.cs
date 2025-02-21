using System;
using System.Collections.Generic;

namespace API.Models;

public partial class File
{
    public string Id { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string? ConferenceId { get; set; }

    public string UploadedBy { get; set; } = null!;

    public DateTime? UploadedAt { get; set; }

    public virtual Conference? Conference { get; set; }

    public virtual User UploadedByNavigation { get; set; } = null!;
}
