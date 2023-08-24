using AuthenticationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.DatabaseContext;

public class UserContext : DbContext
{
    public DbSet<User> User { get; internal set; }
}