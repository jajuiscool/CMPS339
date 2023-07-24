using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Tickets")]
    public class Tickets
    {

        public int Id { get; set; }
        public Attractions? AttractionId { get; set; }

        public static implicit operator Tickets?(TicketsGetDto? v)
        {
            throw new NotImplementedException();
        }
    }

    public class TicketsGetDto
    {
        public int Id { get; set; }
        public int AttractionId { get; set;}

    }

    public class TicketsCreateDto
    {
        [Required]
        public int AttractionId { get; set; }
    }

}
