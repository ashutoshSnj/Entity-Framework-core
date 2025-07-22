using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_freamwork_Start
{
    public class DBConnection: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<studentdata> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MySimpleDB;Trusted_Connection=True;").LogTo(Console.WriteLine,LogLevel.Information);
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MySimpleDB;Trusted_Connection=True;TrustServerCertificate=True").LogTo(Console.WriteLine, LogLevel.Information);
        }

    }
}
