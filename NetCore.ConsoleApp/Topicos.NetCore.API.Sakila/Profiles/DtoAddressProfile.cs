using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.Profiles
{
    public class DtoAddressProfile : Profile
    {
        public DtoAddressProfile()
        {
            CreateMap<Topicos.NetCore.Sakila.Model.MyModels.Address, API.Sakila.MyDtoModels.DtoAddress>();
        }
    }
}
