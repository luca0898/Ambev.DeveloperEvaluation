using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Dtos;
using Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ReverseMap();

            CreateMap<SaleItemDto, SaleItem>().ReverseMap();

            CreateMap<Sale, CreateSaleResult>().ReverseMap();
        }
    }
}
