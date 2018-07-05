using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class City : IEntityBase
    {
        public int ID { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public string CityNameDefault { get; set; }
        public bool IsDeleted { get; set; }
    }
}
