using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    [PrimaryKey(nameof(Email))]
    public class User
    {
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [MaxLength(30)]
        public string? LastName { get; set; }
        [MaxLength(320)]
        public required string Email { get; set; }
        [MaxLength(15)]
        public required string Password { get; set; }

        public User()
        {

        }
    }
}
