using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("AttractionDetails")]
    public class AttractionDetails
    {
        public int Id { get; set; }

        public int AttractionId { get; set; }

        public Attractions? Attraction { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public TimeSpan OpenTime { get; set; }
        [Required]
        public TimeSpan CloseTime { get; set; }

        public int MinimumAge { get; set; }

        public int MinimumHeight { get; set; }

        public decimal TicketPrice { get; set; }
    }

    public class AttractionDetailsCreateDto
    {
        [Required]
        public int AttractionId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public TimeOnly OpenTime { get; set;}
        [Required]
        public TimeOnly CloseTime { get; set;} = new TimeOnly();
        public int MinimumAge { get; set;}
        public int MinimumHeight { get; set;}
        public decimal TicketPrice { get; set;}

    }

}
