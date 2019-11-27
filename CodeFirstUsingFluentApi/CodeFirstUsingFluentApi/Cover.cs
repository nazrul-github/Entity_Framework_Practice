using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstUsingFluentApi
{
   public class Cover
    {
        public int CoverId { get; set; }
        public string CoverName { get; set; }

       
        public Course Course { get; set; }
    }
}
