using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.MyDtoModels
{
    public partial class DtoCustomer
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public DtoAddress Address { get; set; } //propiedad de navegación

        //Navegación a Campos de tabla address
        public string AddressAddress1 { get; set; }
        public string AddressAddress2 { get; set; }
        public string AddressDistrict { get; set; }        
        public string AddressPostalCode { get; set; }
        public string AddressPhone { get; set; }
        public DateTime AddressLastUpdate { get; set; }

        public string AddressCityCity1 { get; set; }//navegación a tabla City
        public string AddressCityCountryCountry1 { get; set; } //Navegación a tabla Country
    }
}
