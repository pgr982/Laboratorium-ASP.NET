using System.ComponentModel.DataAnnotations;

namespace Laboratorium_2.Models
{
    public class Birth
    {
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && BirthDate < DateTime.Now;
        }

        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
