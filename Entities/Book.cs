using System;
using System.Collections.Generic;

namespace Web2BMVC.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }
}
