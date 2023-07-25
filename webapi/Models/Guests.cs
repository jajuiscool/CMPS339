using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Guests")]
    public class Guests
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public Users User { get; set; }

        [Required]
        public char FirstName { get; set; }

        [Required]
        public char LastName { get; set; }

        public string MiddleInitial { get; set; }
        
        public DateOnly Date { get; set; }

    }

    public class GuestsGetDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public char FirstName { get; set; }

        [Required]
        public char LastName { get; set; }

        public string MiddleInitial { get; set; } = string.Empty;
        
        public DateOnly Date { get; set; }
    }

    public class GuestsCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public char FirstName { get; set; }

        [Required]
        public char LastName { get; set; }

        public string MiddleInitial { get; set; } = string.Empty;
    }
}
