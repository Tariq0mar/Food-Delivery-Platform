using Application.DTOs.CustomerModels;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<RegisterDto, Customer>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }
}