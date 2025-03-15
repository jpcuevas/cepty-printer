﻿using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Provider
{
    public Guid Id { get; set; }

    public string? Provider1 { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<ApplicationUserProvider> ApplicationUserProviders { get; set; } = new List<ApplicationUserProvider>();
}
