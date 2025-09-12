using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_inEF
{
  public  abstract class Employe
    {
        [Key]
       public int id { get; set; }
       public  String name {  get; set; }
     public   String Address { get; set; }
        public Employe() { }
        public Employe(String name, String address)
        {
          

            this.name = name;
            this.Address = address;
        }

    }
}
