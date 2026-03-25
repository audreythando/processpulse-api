using Microsoft.EntityFrameworkCore;
using ProcessPulse.Api.Models;

namespace ProcessPulse.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Workflow> Workflows => Set<Workflow>();
}