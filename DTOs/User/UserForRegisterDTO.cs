using System.ComponentModel.DataAnnotations;

namespace iTestApi.DTOs.User
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a correct email address.")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 30 characters")]
        public string Password { get; set; } = null!;

        [Required] 
        public string Name { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}