using Ambev.DeveloperEvaluation.Domain.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerByUserId;

public class GetCustomerByUserIdProfile : Profile
{
    public GetCustomerByUserIdProfile()
    {
        CreateMap<Customer, GetCustomerByUserIdResult>();
    }
}
