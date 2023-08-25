using AuthenticationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.DatabaseContext;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions options)
          : base(options)
    {
    }

    public BaseContext()
    {
    }

    public virtual DbSet<User> Users { get; set; } = default!;
}