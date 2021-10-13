using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Omniaccounts.Models
{
    public class BarCodeViewModel
    {
        public string Company { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        public string Barcode { get; set; }
       
    }
}