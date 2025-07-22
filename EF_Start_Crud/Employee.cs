using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_freamwork_Start
{
    public class Employee
    {
        [Key] 
        public int id {  get; set; }
       public string Name { get; set; }
      public  double Salary { get; set; }
        public Employee() { }
        public Employee( string name, double salary)
        {  
            this.Name = name;   
            this.Salary = salary;

        }
    }
}
