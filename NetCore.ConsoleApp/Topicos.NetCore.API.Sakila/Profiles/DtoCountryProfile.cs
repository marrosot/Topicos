using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.NetCore.API.Sakila.Profiles
{
    public class DtoCountryProfile : Profile
    {
        public DtoCountryProfile()
        {
            CreateMap<Topicos.NetCore.Sakila.Model.MyModels.Country, API.Sakila.MyDtoModels.DtoCountry>();
        }
    }
}
