using System.ComponentModel.DataAnnotations;

namespace FormSubmit.Models
{
    public class User
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required]
        [Range(0,125)]
        public int? Age { get; set; }
        
        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
    }
}