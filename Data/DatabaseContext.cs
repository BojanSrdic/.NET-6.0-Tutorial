
using DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) {}

		public DbSet<Student> Students { get; set; }
	}
}