﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class MenuViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string URL { set; get; }

        public int? DisplayOrder { set; get; }

        public int GroupID { set; get; }

        public virtual MenuGroupViewModel MenuGroup { set; get; }

        public string Target { set; get; }

        public bool Status { set; get; }
    }
}