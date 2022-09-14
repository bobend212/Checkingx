using Checkingx.Shared;
using Microsoft.EntityFrameworkCore;

namespace Checkingx.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Checking> Checkings => Set<Checking>();
    }
}