using Microsoft.EntityFrameworkCore;
using G_Scores.Models;

namespace G_Scores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }

}
