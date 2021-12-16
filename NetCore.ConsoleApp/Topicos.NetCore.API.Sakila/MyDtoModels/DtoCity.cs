using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.MyDtoModels
{
    public partial class DtoCity
    {
        
        public string City1 { get; set; }
        public short CountryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public DtoCountry Country { get; set; }
    }
}
