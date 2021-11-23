using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.AdventureWorks.Profiles
{
    public class DtoCustomerAddressProfile : Profile
    {
        public DtoCustomerAddressProfile()
        {
            CreateMap<Topicos.NetCore.NorthWind.Model.MyModels.CustomerAddress, API.AdventureWorks.MyDtoModels.DtoCustomerAddress>();
        }
    }
}
