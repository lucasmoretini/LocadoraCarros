using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dados.Models;
using LocadoraDeCarros.Models;
using Negocio.Models;

namespace LocadoraDeCarros.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteDataModel>().ReverseMap();
        }

    }
}
