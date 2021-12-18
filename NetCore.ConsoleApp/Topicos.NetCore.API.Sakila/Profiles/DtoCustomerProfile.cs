using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.Profiles
{
    public class DtoCustomerProfile : Profile
    {
        public DtoCustomerProfile()
        {
            CreateMap<Topicos.NetCore.Sakila.Model.MyModels.Customer, API.Sakila.MyDtoModels.DtoCustomer>();
        }
    }
}
