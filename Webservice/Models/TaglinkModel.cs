﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webservice.Models
{
    public class TaglinkModel : LinkedResourceModel
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public TagModel Tag { get; set; }
    }
}
