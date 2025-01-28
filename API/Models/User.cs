using System.ComponentModel.DataAnnotations;
// using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Models {
    public class User 
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "customer";
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
}