using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EtbnanyWebsite.Models
{
    public class Donation
    {
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        [Key, Column(Order = 2)]
        public int UserId { get; set; }
        public int quantity { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}