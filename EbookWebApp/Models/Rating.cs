using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbookWebApp.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public string AplicationUserId { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }

    }
}