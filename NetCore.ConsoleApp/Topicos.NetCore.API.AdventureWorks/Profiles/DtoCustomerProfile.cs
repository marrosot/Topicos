using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.AdventureWorks.Profiles
{
    public class DtoCustomerProfile : Profile
    {
        public DtoCustomerProfile()
        {
            CreateMap<Topicos.NetCore.NorthWind.Model.MyModels.Customer, API.AdventureWorks.MyDtoModels.DtoCustomer>();
        }
    }
}
