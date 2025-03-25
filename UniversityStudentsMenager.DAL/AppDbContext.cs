

using Microsoft.EntityFrameworkCore;

namespace UniversityStudentsMenager.DAL
{
    internal class AppDbContext : DbContext
    {
        private string _connection_str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsUniversity;Integrated Security=True;Connect Timeout=30;";

        public DbSet<Entities.Student> Students { get; set; }

        /*public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
            
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection_str);
        }

    }
}
