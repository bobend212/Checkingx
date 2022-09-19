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
        public DbSet<Checking> Checking => Set<Checking>();
        public DbSet<CheckItem> CheckItems => Set<CheckItem>();
        public DbSet<Image> Images => Set<Image>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckItem>().HasData(
                new CheckItem { CheckItemId = 1, Title = "Ensure slab follows outline of ground floor.", Category = "SLAB", Priority = 3 },
                new CheckItem { CheckItemId = 2, Title = "Batten line is not shown on slab.", Category = "SLAB", Priority = 2 },
                new CheckItem { CheckItemId = 3, Title = "All load bearing walls are indicated.", Category = "SLAB", Priority = 3 },
                new CheckItem { CheckItemId = 4, Title = "All internal and external walls dimensioned and dimensions are accurate.", Category = "ROOF", Priority = 1 },
                new CheckItem { CheckItemId = 5, Title = "Cross dimensions are shown.", Category = "PANELS", Priority = 1 },
                new CheckItem { CheckItemId = 6, Title = "Point load symbols shown and dimensioned. Point loads are split for joinery", Category = "PANELS", Priority = 2 },
                new CheckItem { CheckItemId = 7, Title = "All point loads end up on a sufficient beam or a load bearing wall.", Category = "PANELS", Priority = 3 },
                new CheckItem { CheckItemId = 8, Title = "Portal panel shoes shown and dimensioned. Note added to ensure coursing blocks are left out where the shoe is positioned.", Category = "FLOOR", Priority = 1 },
                new CheckItem { CheckItemId = 9, Title = "Slab edge distance and spacing between bolts connecting portal frames/steel posts are correct.", Category = "FLOOR", Priority = 1 },
                new CheckItem { CheckItemId = 10, Title = "If step in slab level appears, it is clearly indicated and detail is added.", Category = "PANELS", Priority = 2 }
            );
        }
    }
}