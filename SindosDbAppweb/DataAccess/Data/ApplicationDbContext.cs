using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SindosDbAppweb.Models;

namespace SindosDbAppweb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Staff> STAFF { get; set; }
        public DbSet <Student> STUDENTS { get; set; }
        public DbSet<Event> EVENTS { get; set; }
        public DbSet<Project> PROJECTS { get; set; }
        public DbSet<School> SCHOOLS { get; set; }
        public DbSet<Sex> SEXS { get; set; }
        public DbSet<Abroad> ABROADS { get; set; }
    }
}
