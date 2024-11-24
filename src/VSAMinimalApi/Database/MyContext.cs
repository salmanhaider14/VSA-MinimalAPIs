using Microsoft.EntityFrameworkCore;
using VSAMinimalApi.Database.Models;

namespace VSAMinimalApi.Database;

public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; } = null!;
}