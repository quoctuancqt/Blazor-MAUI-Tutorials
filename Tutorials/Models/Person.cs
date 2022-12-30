using System.ComponentModel.DataAnnotations;

namespace BlazorTutorial.Models
{
    public class Person
    {
        public string Salutation { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
        public int Age { get; set; }
    }
}
