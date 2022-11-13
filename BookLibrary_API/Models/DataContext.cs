using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookLibrary_API.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<Book> Books { get; set; }
}
