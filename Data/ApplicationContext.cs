using Interview_Schedule_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview_Schedule_Management.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public ApplicationContext()
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<AspirantApplication> Applicants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R551R0S;Initial Catalog=JOY;Integrated Security=True");
        }
    }
}
