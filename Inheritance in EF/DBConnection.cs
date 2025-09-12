using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_inEF
{
    public class DBConnection : DbContext
    {
        public DbSet<Employe> Employe { get; set; }
      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Employedata;  Trusted_Connection=True;
                  Encrypt=True;
                  TrustServerCertificate=True;").LogTo(Console.WriteLine);
        }*/
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=localhost;Database=Employedata;Trusted_Connection=True;
                        Encrypt=True;
                        TrustServerCertificate=True;")
                .LogTo(Console.WriteLine,
                       new[] { DbLoggerCategory.Database.Command.Name }, // only SQL commands
                       Microsoft.Extensions.Logging.LogLevel.Information) // filter log level
                .EnableSensitiveDataLogging(); // optional: logs parameter values too
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>().HasDiscriminator<String>("EmployeeTYpe").HasValue<Employe>("EmployeeTypee").HasValue<FullTimeEmployee>("FullTime").HasValue<PartTimeEmployee>("parttime");
        }
    }
}
