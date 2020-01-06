using System;
using System.ComponentModel.DataAnnotations;

namespace BookListR.Model
{
    public class CBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

    }


}
