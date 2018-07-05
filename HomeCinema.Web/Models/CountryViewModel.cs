using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class CountryViewModel
    {
        public int ID { get; set; }
        public int CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryNameDefault { get; set; }
        public bool IsDeleted { get; set; }
    }
}