using System.ComponentModel.DataAnnotations;

namespace SAT_Project.UI.MVC.Models
{
        
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Name is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "* Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(13, ErrorMessage = "Must not exceed 13 digits")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; } = null!;

        [Required(ErrorMessage = "* Message is Required")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; } = null!;
                
    }
}
