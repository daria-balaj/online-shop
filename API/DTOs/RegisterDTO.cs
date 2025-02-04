using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.DTOs {
    public class RegisterDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        [StringLength(16, MinimumLength = 6)]
        [Required] 
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "customer";
    }
}