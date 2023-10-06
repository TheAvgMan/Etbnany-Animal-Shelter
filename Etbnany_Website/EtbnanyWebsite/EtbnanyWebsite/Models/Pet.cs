using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EtbnanyWebsite.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public bool isAdopted { get; set; }
        public string image { get; set; }

        public Adoption Adoption { get; set; }

    }
}