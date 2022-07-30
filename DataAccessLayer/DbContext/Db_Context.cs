using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class Db_Context : DbContext
    {
        public Db_Context(DbContextOptions<Db_Context> options):base(options)
        {
           
        }

        public DbSet<ServiceCategories> ServiceCategories { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<Portofolio> Portofolio { get; set; }
        public DbSet<PortofolioVideo> PortofolioVideo { get; set; }
        public DbSet<PortofolioItems> PortofolioItems { get; set; }
        public DbSet<Client> Client { get; set; }


        /// //////////////////////////////////////////////////////
        public DbSet<REQUEST_PROPOSAL> REQUEST_PROPOSAL { get; set; }
        public DbSet<KEYWORDS> KEYWORDS { get; set; }
        public DbSet<NEWS> NEWS { get; set; }
        public DbSet<EVENTS> EVENTS { get; set; }
        public DbSet<OUR_TEAM> OUR_TEAM { get; set; }
        /// //////////////////////////////////////////////////////////

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
     
        }
         
    }
}
