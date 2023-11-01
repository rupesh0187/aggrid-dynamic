using Microsoft.EntityFrameworkCore;

namespace aggrid_dynamic.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) :base(options) 
        {

        }
        public DbSet<Student> Students { get;set; }
    }
}
