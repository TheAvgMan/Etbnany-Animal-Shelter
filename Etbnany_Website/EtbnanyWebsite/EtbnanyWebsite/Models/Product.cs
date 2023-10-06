using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EtbnanyWebsite.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string image { get; set; }
        public  int stock { get; set; }


        public ICollection<Donation> Donations { get; set; }

    }
}