using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Author { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}