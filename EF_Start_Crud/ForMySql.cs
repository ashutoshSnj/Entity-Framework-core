using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_freamwork_Start
{
    public class ForMySql : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<studentdata> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string url = "server=localhost;database=fbs;user=root;password=#Ashutosh.snj79;";
            optionsBuilder.UseMySql(url,ServerVersion.AutoDetect(url));
        }

    }
}
