using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EtbnanyWebsite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }

        public ICollection<Enquiry> Enquiries { get; set; }
        public ICollection<Adoption> Adoptions { get; set; }
        public ICollection<Donation> Donations { get; set; }
    }
}