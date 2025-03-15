using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public string? ApplicationUserId { get; set; }

    public virtual AspNetUser? ApplicationUser { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
