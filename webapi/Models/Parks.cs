﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Parks")]
    public class Parks
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }    

    }

    public class ParksGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

    }

    public class ParksCreateDto
    {
        [Required]
        [MaxLength(30)]

        public string Name { get; set; } = string.Empty;
    }

    public class ParksUpdateDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
    }

}
