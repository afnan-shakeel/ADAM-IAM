using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Users")]
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 characters")]
        public string Email { get; set; }
        // public List<Role> Roles { get; set; }
    }
}