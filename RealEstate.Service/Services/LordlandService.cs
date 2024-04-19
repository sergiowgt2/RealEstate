using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Service.Interfaces;
using RealEstate.Service.Model;
using RealEstate.Service.Services.Exceptions;
using RealEstate.Service.Services.Interfaces;

namespace RealEstate.Service.Services;

public class LandLordService : ILandLordService
{
    private ILandLordRepository _repo; 
    private readonly IMapper _mapper;
    public LandLordService(IMapper mapper, ILandLordRepository repo)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task Insert(LandLordInsertModel toAdd)
    {
        ServiceException.When(_repo.GetByName(toAdd.Name, null) != null, $"Landlord name already exists. [Name={toAdd.Name}]");
        ServiceException.When(_repo.GetByEmail(toAdd.Email, null) != null, $"Landlord email already exists. [Email={toAdd.Email}]");
        ServiceException.When(_repo.GetByCellPhone(toAdd.CellPhone, null) != null, $"Landlord CellPhone already exists. [Cellphone={toAdd.CellPhone}]");
        
        var newLandLord = _mapper.Map<LandLordInsertModel, Landlord>(toAdd);
        newLandLord.Status = EntityStatusEnum.Active;
        newLandLord.CreatedAt = DateTime.Now;
        newLandLord.Id = new Guid();
        await _repo.Add(newLandLord);
    }
    public async Task Activate(Guid id, string UpdatedBy)
    {
        var landLord = await _repo.Get(id);
        if (landLord == null) 
            ServiceException.When(true, $"Landlord does not exist. [Id={id}]");
        
        ServiceException.When(landLord.Status == EntityStatusEnum.Active, $"Landlord already active. [Id={id}]");
        landLord.Status = EntityStatusEnum.Active;
        landLord.UpdatedAt = DateTime.Now;
        landLord.UpdatedBy = UpdatedBy;
        await _repo.Update(landLord);
    }
    public async Task Deactivate(Guid id, string UpdatedBy)
    {
        var landLord = await _repo.Get(id);
        if (landLord == null) 
            ServiceException.When(true, $"Landlord does not exist. [Id={id}]");
        
        ServiceException.When(landLord.Status == EntityStatusEnum.Inactive, $"Landlord already Inactive. [Id={id}]");
        landLord.Status = EntityStatusEnum.Inactive;
        landLord.UpdatedAt = DateTime.Now;
        landLord.UpdatedBy = UpdatedBy;
        await _repo.Update(landLord);
    }
}