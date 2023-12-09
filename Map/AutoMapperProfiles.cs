using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidotnet.Entity;
using apidotnet.Model;
using AutoMapper;

namespace apidotnet.Map
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Livro, LivroModel>().ReverseMap();
        }
    }
}