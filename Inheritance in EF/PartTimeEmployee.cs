using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_inEF
{
    public class PartTimeEmployee : Employe
    {
        public PartTimeEmployee() { }
        public String Possiblity { get; set; }

        public PartTimeEmployee( String name, String Address, String possiblity) : base( name, Address)
        {
            this.Possiblity= possiblity;
        }
        

    }
    
    
}

