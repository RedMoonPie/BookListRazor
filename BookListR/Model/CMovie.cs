using System;
using System.ComponentModel.DataAnnotations;

namespace BookListR.Model
{
    public class CMovie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Year { get; set; }

        public string Director { get; set; }
    }
}
