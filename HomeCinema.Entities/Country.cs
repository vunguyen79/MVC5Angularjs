using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{

    public class Country : IEntityBase
    {
        public int ID { get; set; }
        public int CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryNameDefault { get; set; }
        public bool IsDeleted { get; set; }
    }
}
