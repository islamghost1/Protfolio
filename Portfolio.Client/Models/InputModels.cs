using System.ComponentModel.DataAnnotations;

namespace Portfolio.Client.Models
{
    public class PhoneNumberModel
    {
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"\+\d\(\d{3}\) \d{3}-\d{4}", ErrorMessage = "Phone number must be in the format +X(XXX) XXX-XXXX.")]
        public string PhoneNumber { get; set; }
    }

    public class EmailModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
    }

    public class AddressModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
