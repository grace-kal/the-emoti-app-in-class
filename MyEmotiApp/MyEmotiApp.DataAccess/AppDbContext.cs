using Microsoft.EntityFrameworkCore;
using MyEmotiApp.Models;

namespace MyEmotiApp.DataAccess
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}