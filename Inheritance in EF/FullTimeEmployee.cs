using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_inEF
{
   public  class FullTimeEmployee:Employe
    {
        public int PfPresent {  get; set; }
        public FullTimeEmployee() { }
        public FullTimeEmployee(String name,String Address ,int pf):base(name,Address)
        {
            this.PfPresent = pf;
        }
        
    }
}
