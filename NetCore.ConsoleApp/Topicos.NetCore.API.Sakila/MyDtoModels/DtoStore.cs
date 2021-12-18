using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.MyDtoModels
{
    public partial class DtoStore
    {
        public int StoreId { get; set; }
        public byte ManagerStaffId { get; set; }
        public int AddressId { get; set; }
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
