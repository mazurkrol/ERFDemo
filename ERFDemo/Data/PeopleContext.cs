using Microsoft.EntityFrameworkCore;
using ERFDemo.Models;

namespace ERFDemo.Data
{
	public class PeopleContext : DbContext 
	{
		public PeopleContext(DbContextOptions options) : base(options) { }
		public DbSet<Person> Person { get; set; }
	}
}
