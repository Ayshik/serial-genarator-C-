using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialdr
{
   public class prop
    {
        DataAccess da = new DataAccess();

        public string Name { get; set; }
        public string Catagory { get; set; }
        public string Room { get; set; }
        public string PhoneNumber { get; set; }
        public string Patient { get; set; }
       
    }
}
