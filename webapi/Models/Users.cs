using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int IsActive { get; set; }

        public List<Guests>? Guests { get; set; }
    }

    public class UsersGetDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public int IsActive { get; set; }
    }

    public class UsersCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
