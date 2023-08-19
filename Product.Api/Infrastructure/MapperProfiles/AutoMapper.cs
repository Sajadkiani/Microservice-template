using AutoMapper;
using Product.Api.Application.Commands.Products;
using Product.Api.ViewModels;
using Product.Domain.Aggregates.Users;

namespace Product.Api.Infrastructure.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductViewModel.AddProductInput, AddProductCommand>();
        }
    }
}