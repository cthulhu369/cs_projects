using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        optionsBuilder.UseSqlite("Filename=Payments.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().ToTable("Transaction");
    }

    public DbSet<Transaction> Transactions { get; set; }

}