using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać treść")]
        [StringLength(maximumLength: 2000, ErrorMessage = "Treść posta nie może być dłuzsza niż 2000 znaków")]
        [Display(Name = "Treść")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Podaj autora")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [HiddenInput]
        public DateTime PostDate { get; set; }

        [Required(ErrorMessage = "Musisz podać przynajmniej jeden tag")]
        [Display(Name = "Tagi")]
        public string Tags { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Komentarz nie może być dłuższy niż 500 znaków")]
        [Display(Name = "Komentarz")]
        public string? Comment { get; set; }

    }
}
