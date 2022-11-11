using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Data
{
    public class UserDbContext: DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        //public DbSet<CourseModel> Courses { get; set; }
        public UserDbContext()
        {

        }
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Database=UserManagementDB;Trusted_Connection=true;"); 

        }
    }
}
