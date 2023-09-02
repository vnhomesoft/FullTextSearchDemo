using Microsoft.EntityFrameworkCore;

namespace FulltextSearchDemo;
public class AppDbContext : DbContext {
    public DbSet<Product> Products { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // For PostgreSQL fulltext support, reference
        // https://www.npgsql.org/efcore/mapping/full-text-search.html?tabs=pg12%2Cv5
        modelBuilder.Entity<Product>()
        .HasGeneratedTsVectorColumn(
            p => p.SearchVector,
            "english",  // Text search config
            p => new { p.Name, p.Description } )  // Included properties
        .HasIndex( p => p.SearchVector )
        .HasMethod( "GIN" ); // Index method on the search vector (GIN or GIST)

        this.SeedData( modelBuilder );
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product {Id = 1, Name= "Cá thu", Description = "Cá hầm cà chua đóng lon"} );
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 2, Name = "Rau xà lách", Description = "Rau xanh 1kg" } );
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 3, Name = "Ớt chuông", Description = "Ớt chuông xanh, đỏ, vàng" } );
    }
}