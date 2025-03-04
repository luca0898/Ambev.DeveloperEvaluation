using Ambev.DeveloperEvaluation.Application.Customers.GetCustomerByUserId;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomerByUserId;

public class GetCustomerByUserIdProfile : Profile
{
    public GetCustomerByUserIdProfile()
    {
        CreateMap<GetCustomerByUserIdRequest, GetCustomerByUserIdCommand>();
        CreateMap<GetCustomerByUserIdResult, GetCustomerByUserIdResponse>().ReverseMap();
    }
}
