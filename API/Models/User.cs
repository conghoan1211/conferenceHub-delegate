using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;

    public int? PositionId { get; set; }

    public string? Company { get; set; }

    public string? Avatar { get; set; }

    public string? GoogleId { get; set; }

    public int? Sex { get; set; }

    public DateTime? Dob { get; set; }

    public int RoleId { get; set; }

    public int? Status { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsVerified { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? CreateUser { get; set; }

    public string? UpdateUser { get; set; }

    public virtual ICollection<ConferenceDelegate> ConferenceDelegates { get; set; } = new List<ConferenceDelegate>();

    public virtual ICollection<Conference> Conferences { get; set; } = new List<Conference>();

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual Position? Position { get; set; }
}
