using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.DTOs {
    public class RegisterDTO
    {
        [Required] public int Id { get; set; }

        [Required] public string? FirstName { get; set; }

        [Required] public string? LastName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string? Phone { get; set; }

        [StringLength(16, MinimumLength = 6)]
        [Required] 
        public string Password { get; set; }
    }
}