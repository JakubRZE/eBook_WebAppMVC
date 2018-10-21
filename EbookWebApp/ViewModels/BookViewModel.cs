using EbookWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookWebApp.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [Display(Name = "Rating")]
        public double? Overall { get; set; }
    }
}