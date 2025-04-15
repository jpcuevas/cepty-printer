using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string Discriminator { get; set; } = null!;

    public string? Name { get; set; }

    public string? UserImage { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<ApplicationUserProvider> ApplicationUserProviders { get; set; } = new List<ApplicationUserProvider>();

    public virtual ICollection<AspNetUserClaim> AspNetUserClaimApplicationUsers { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserClaim> AspNetUserClaimUsers { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
