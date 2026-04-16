using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : 
    DbContext(options)
{
    public DbSet<Games> Games { get; set; }
    public DbSet<Genre> Genre {get; set; }
}
