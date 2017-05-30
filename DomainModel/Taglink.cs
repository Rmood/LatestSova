using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Taglink
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        //public int Value { get; set; }


    }
}
