using Microsoft.EntityFrameworkCore;
using CromosApi.Models;

namespace CromosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cromo> Cromos { get; set; }
    }
}