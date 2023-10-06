using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EtbnanyWebsite.Models
{
    public class Adoption
    {
        [Key, ForeignKey("Pet")]
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string message { get; set; }
        

        public Pet Pet { get; set; }
        public User User { get; set; }
    }
}