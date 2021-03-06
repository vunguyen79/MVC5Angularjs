﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class ProfileUserViewModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string License { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
    }
}