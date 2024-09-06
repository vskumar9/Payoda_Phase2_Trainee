using API_JWT_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Application.Models
{
    public class APIDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Users> UsersJWT { get; set; }
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
    }
}
