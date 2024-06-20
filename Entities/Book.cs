using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web2BMVC.Entities;

public partial class Book
{
    public int Id { get; set; }

    [DisplayName("Book Name")]
    [Required(ErrorMessage = "Kuwang Name kay is required")]
    public string? Name { get; set; }

    [DisplayName("Book Author")]
    [Required(ErrorMessage = "Author is required")]
    [MaxLength(5, ErrorMessage = "Author cannot be longer than 5 characters")]
    public string? Author { get; set; }
}
