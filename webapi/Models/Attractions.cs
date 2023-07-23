using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    [Table("Attractions")]
    public class Attractions
    {

        public int Id { get; set; }

        public int ParkId { get; set; }

        public Parks? Park { get; set; }

        public AttractionDetails? Details { get; set; }

    }

    public class AttractionsGetDto
    {
        public int Id { get; set; }

        public int ParkId { get; set; }

    }

    public class AttractionsCreateDto
    {
        [Required]

        public int ParkId { get; set; }
    }


}
