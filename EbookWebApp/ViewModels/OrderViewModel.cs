using EbookWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbookWebApp.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public string AplicationUserId { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }
    }
}