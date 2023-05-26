using Microsoft.EntityFrameworkCore;
using WebApiChallange.Models;

namespace WebApiChallange.Context
{
	public class ApiDbContext : DbContext 
	{
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {}
        public DbSet<Video> Videos { get; set; }
        public DbSet<Category> Categories { get; set; }

	}
}
