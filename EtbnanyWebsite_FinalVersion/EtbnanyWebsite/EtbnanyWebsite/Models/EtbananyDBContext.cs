using System.Data.Entity;

namespace EtbnanyWebsite.Models
{
    public class EtbananyDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Donation> Donations { get; set; }

    }
}