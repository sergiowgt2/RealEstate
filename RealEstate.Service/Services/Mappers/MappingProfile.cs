using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Service.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LandlordInsertModel, Landlord>();
    }
}

