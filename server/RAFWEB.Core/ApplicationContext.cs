using Microsoft.EntityFrameworkCore;
using RAFWEB.Data.Models;

namespace RAFWEB.Core
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        public DbSet<Article> Article { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<ContactInfo> Contact { get; set; }

        public DbSet<StudentOrganization> Organization { get; set; }

        public DbSet<Holiday> Holiday { get; set; }

        public DbSet<MainPageContent> MainPage { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }
    }
}
