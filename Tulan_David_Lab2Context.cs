using Microsoft.EntityFrameworkCore;

public class Tulan_David_Lab2Context(DbContextOptions<Tulan_David_Lab2Context> options) : DbContext(options)
{
    public DbSet<Tulan_David_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Tulan_David_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Tulan_David_Lab2.Models.Author> Author { get; set; } = default!;
}