using AutoMapper;
using InGame.Dtos;
using InGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGame.WebApi.AutoAMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                     .ForMember(dest => dest.HasChild,
                                opt => opt.MapFrom
                                (src => src.SubCategories.Count > 0 ? true : false));
        }
    }
}
