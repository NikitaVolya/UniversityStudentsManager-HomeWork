

using Microsoft.EntityFrameworkCore;
using UniversityStudentsMenager.DAL.Entities;

namespace UniversityStudentsMenager.DAL
{
    internal class AppDbContext : DbContext
    {
        private string _connection_str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsUniversity;Integrated Security=True;Connect Timeout=30;";

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        /*public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
            
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection_str);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserID).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
