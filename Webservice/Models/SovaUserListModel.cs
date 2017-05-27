using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webservice.Models
{
    public class SovaUserListModel : LinkedResourceModel
    {
        //public int Id { get; set; }
        public string Nick { get; set; }
        public string Country { get; set; }
    }
}
