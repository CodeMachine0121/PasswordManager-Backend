using Microsoft.EntityFrameworkCore;
using PasswordManager.Models.Entities;

namespace PasswordManager.DataBases;

public class PasswordManagerDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<StoredPassword> StoredPasswords { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoredPassword>().ToTable("Passwords");
    }
}