using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EbookWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OrderDate { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public string AplicationUserId { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }
    }
}