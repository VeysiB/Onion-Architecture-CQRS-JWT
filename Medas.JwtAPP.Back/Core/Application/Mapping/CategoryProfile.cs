using AutoMapper;
using Medas.JwtAPP.Back.Core.Application.Dtos;
using Medas.JwtAPP.Back.Core.Domain;

namespace Medas.JwtAPP.Back.Core.Application.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
