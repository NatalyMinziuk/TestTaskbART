using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Enteties;

namespace TestTask.DAL
{
    public class TestTaskDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public TestTaskDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().Property(x => x.Name).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Account>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasMany(c => c.Contacts)
                .WithOne(e => e.Account);

            modelBuilder.Entity<Incident>()
               .HasMany(c => c.Accounts)
               .WithOne(e => e.Incident);
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}
