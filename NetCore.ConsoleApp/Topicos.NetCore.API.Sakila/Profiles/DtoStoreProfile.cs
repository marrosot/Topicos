using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.Profiles
{
    public class DtoStoreProfile : Profile
    {
        public DtoStoreProfile()
        {
            CreateMap<Topicos.NetCore.Sakila.Model.MyModels.Store, API.Sakila.MyDtoModels.DtoStore>();
        }
    }
}
