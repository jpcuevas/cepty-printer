using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class ApplicationUserProvider
{
    public Guid CompanyId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime PublicationDate { get; set; }

    public virtual Provider Company { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
