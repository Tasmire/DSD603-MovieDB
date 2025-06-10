using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieDB.Models;

namespace DSD603_MovieDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieDB.Models.Cast> Cast { get; set; } = default!;
        public DbSet<MovieDB.Models.Movie> Movie { get; set; } = default!;
        public IEnumerable<object> Casts { get; internal set; }
    }
}
