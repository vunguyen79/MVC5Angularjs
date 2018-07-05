namespace HomeCinema.Web.Models
{
    public class CityViewModel
    {
        public int ID { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public string CityNameDefault { get; set; }
        public bool IsDeleted { get; set; }
    }
}