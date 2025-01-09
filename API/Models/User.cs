using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Models {
    public class User : IdentityUser<int>
    {
        [Key]
        private int ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }

        // public User(int userId, string email, string firstName, string lastName, string password)
        // {
        //     UserID = userId;
        //     Email = email;
        //     FirstName = firstName;
        //     LastName = lastName;
        //     Password = password;
        // }
    }
}