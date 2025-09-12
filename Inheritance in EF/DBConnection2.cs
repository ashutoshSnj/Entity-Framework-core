using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_inEF
{
    public class DBConnection2 : DbContext
    {
      public  DbSet<Employe> Employes { get; set; }
    public    DbSet<FullTimeEmployee> FullTimeEmployee { get; set; }
      public  DbSet<PartTimeEmployee> PartTimeEmployee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=localhost;Database=Employedata2;Trusted_Connection=True;
                                Encrypt=True;TrustServerCertificate=True;")
                .LogTo(Console.WriteLine,
                       new[] { DbLoggerCategory.Database.Command.Name },
                       Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table-per-Type (TPT) mapping
            modelBuilder.Entity<Employe>().ToTable("Employees");
            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployees");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployees");
        }
    }
}
    

