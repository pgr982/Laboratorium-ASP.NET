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
        public string Content { get; set; }
        [Required(ErrorMessage = "Podaj autora")]
        public string Autor { get; set; }
        [HiddenInput]
        public DateTime PostDate { get; set; }
        [Required(ErrorMessage = "Musisz podać przynajmniej jeden tag")]
        public string Tags { get; set; }
        [StringLength(maximumLength: 500, ErrorMessage = "Komentarz nie może być dłuższy niż 500 znaków")]
        public string Comment { get; set; }

    }
}
