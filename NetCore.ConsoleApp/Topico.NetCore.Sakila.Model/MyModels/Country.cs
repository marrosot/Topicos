﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Topico.NetCore.Sakila.Model.MyModels
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public short CountryId { get; set; }
        public string Country1 { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
