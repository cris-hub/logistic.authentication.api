using AuthenticationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.DatabaseContext
{
    public interface IUserContext
    {
        public DbSet<User> User { get; set; }
    }
}