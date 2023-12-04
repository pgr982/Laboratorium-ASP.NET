using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imie, max 50 znaków")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Proszę podać numer telefonu!")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Data urodzenia")]
        public DateTime? Birth { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }

        [HiddenInput]
        public int OrganizationId { get; set; }

        [ValidateNever]
        public string OrganizationName { get; set; }

        [ValidateNever]
        public List<SelectListItem> Organizations { get; set; }
    }
}
