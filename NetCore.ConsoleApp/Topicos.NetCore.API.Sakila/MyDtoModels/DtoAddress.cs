using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.MyDtoModels
{
    public partial class DtoAddress    {
       
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string District { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime LastUpdate { get; set; }

        public DtoCity City { get; set; }

    }
}
