using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.AdventureWorks.Profiles
{
    public class DtoAddressProfile : Profile
    {
        public DtoAddressProfile()
        {
            CreateMap<Topicos.NetCore.NorthWind.Model.MyModels.Address, Topicos.NetCore.API.AdventureWorks.MyDtoModels.DtoAddress>();
        }
    }
}
