using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.Profiles
{
    public class DtoCityProfile : Profile
    {
        public DtoCityProfile()
        {
            CreateMap<Topicos.NetCore.Sakila.Model.MyModels.City, API.Sakila.MyDtoModels.DtoCity>();
        }
    }
}
