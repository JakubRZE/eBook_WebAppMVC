using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookWebApp.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMMM}")]
        public DateTime ReleaseDate { get; set; }

        public double? Overall { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}