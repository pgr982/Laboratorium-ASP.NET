using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class Contact
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Proszę podać imię!")]
    public string Name { get; set; }

    [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
    [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
    public string Email { get; set; }

    public string Subject { get; set; }

    public string? Phone { get; set; }
    public DateTime? Birth { get; set; }

}
