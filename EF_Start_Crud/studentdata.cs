using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_freamwork_Start
{
    public class studentdata
    {
        [Key]
        public int id {  get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
