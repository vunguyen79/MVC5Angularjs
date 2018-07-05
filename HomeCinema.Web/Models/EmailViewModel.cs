using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class EmailViewModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}