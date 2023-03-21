using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TranscriptApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TranscriptApp.Models.Session> Sessions { get; set; }
        public DbSet<TranscriptApp.Models.Department>Departments { get; set; }
        public DbSet<TranscriptApp.Models.Faculty> Faculties { get; set; }
        public DbSet<TranscriptApp.Models.Course> Courses { get; set; }
        public DbSet<TranscriptApp.Models.FinalApprovedResult> FinalApprovedResults { get; set; }



    }
}