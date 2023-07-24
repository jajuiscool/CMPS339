using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Users")]
    public class Users
    {

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public bool? IsActive { get; set; }
    }

    public class UsersGetDto
    {
        public int Id { get; set; }
        public string? Username { get; set;}
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }

    public class UsersCreateDto
    {
        [Required]
        public int Id { get; set; }
    }
}
