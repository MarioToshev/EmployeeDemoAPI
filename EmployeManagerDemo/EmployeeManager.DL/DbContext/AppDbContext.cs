using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmoloyeeManager.DL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}