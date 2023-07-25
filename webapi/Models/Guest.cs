using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Guests
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public string FirstName { get; set; }
        public char MiddleInitial { get; set; }
        public string LastName { get; set; }
        public DateOnly DOB { get; set; }
    }

    public class GuestsGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }

    public class GuestsCreateDto
    {
        [Required]
        public int Id { get; set; }
    }
}
