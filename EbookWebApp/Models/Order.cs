using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EbookWebApp.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        public int? Rank { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OrderDate { get; set; }

        [Required]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        [Required]
        public string AplicationUserId { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }
    }
}