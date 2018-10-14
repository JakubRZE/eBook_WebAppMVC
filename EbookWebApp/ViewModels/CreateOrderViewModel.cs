using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookWebApp.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}