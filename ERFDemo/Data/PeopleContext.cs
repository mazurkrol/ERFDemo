using Microsoft.EntityFrameworkCore;
using ERFDemo.Models;
using System.Text.RegularExpressions;

namespace ERFDemo.Data
{
	public class PeopleContext : DbContext 
	{
        public DbSet<Address> Address { get; set; }
        public PeopleContext(DbContextOptions options) : base(options) { }
		public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  //dodajemy parę kluczy do tabeli pośredniczącej do relacji many to many
            builder.Entity<PersonGroup>().HasKey(pg => new { pg.PersonId, pg.GroupId });    //w tabeli posredniczacej PersonGroup
            builder.Entity<PersonGroup>()
            .HasOne<Person>(pg => pg.Person) // dla jednej osoby
            .WithMany(p => p.PersonGroups) // jest wiele PersonGroups
            .HasForeignKey(p => p.PersonId); // a powizanie jestrealizowane przez klucz obcy PersonId
            builder.Entity<PersonGroup>()                                      //w tabeli posredniczacej PersonGroup
            .HasOne<ERFDemo.Models.Group>(pg => pg.Group)   // dla jednej grupy
            .WithMany(g => g.PersonGroups)                                                                                        // jest wiele PersonGroups
            .HasForeignKey(g => g.GroupId); // a powizanie jest realizowane przez klucz obcy GroupId
        }
    }
}
