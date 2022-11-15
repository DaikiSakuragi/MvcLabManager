using Microsoft.EntityFrameworkCore;

namespace MvcLabManager.Models;

public class LabManagerContext : DbContext
{
    public DbSet<Computer> Computers { get; set; }
    public DbSet<Laboratory> Laboratorys { get; set; }
    
    public LabManagerContext(DbContextOptions<LabManagerContext> options) : base(options)
    {
        
    }
}