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

    private async Task<Landlord> GetLandLord(Guid id)
    {
        var landLord = await _repo.Get(id);
        if (landLord == null) 
            ServiceException.When(true, $"Landlord does not exist. [Id={id}]");

        return landLord;
    }

    public async Task Insert(LandlordInsertModel toAdd, string CreateBy)
    {
        ServiceException.When(await _repo.GetByName(toAdd.Name, null) != null, $"Landlord name already exists. [Name={toAdd.Name}]");
        ServiceException.When(await _repo.GetByEmail(toAdd.Email, null) != null, $"Landlord email already exists. [Email={toAdd.Email}]");
        ServiceException.When(await _repo.GetByCellPhone(toAdd.CellPhone, null) != null, $"Landlord CellPhone already exists. [Cellphone={toAdd.CellPhone}]");
        ServiceException.When(await _repo.GetByCpfCnpj(toAdd.CnpjCpf, null) != null, $"Landlord CpfCnpj already exists. [Cellphone={toAdd.CnpjCpf}]");
        
        var newLandLord = _mapper.Map<LandlordInsertModel, Landlord>(toAdd);
        newLandLord.Status = EntityStatusEnum.Active;
        newLandLord.CreatedAt = DateTime.Now;
        newLandLord.CreatedBy = CreateBy;
        newLandLord.Id = new Guid();
        await _repo.Add(newLandLord);
    }
    
    public async Task Update(LandlordUpdateModel toUpdate, string UpdatedBy)
    {
        var landLord = await GetLandLord(toUpdate.Id);
        
        ServiceException.When(_repo.GetByName(toUpdate.Name, toUpdate.Id) != null, $"Landlord name already exists. [Name={toUpdate.Name}]");
        ServiceException.When(_repo.GetByEmail(toUpdate.Email,toUpdate.Id) != null, $"Landlord email already exists. [Email={toUpdate.Email}]");
        ServiceException.When(_repo.GetByCellPhone(toUpdate.CellPhone, toUpdate.Id) != null, $"Landlord CellPhone already exists. [Cellphone={toUpdate.CellPhone}]");
        
        _mapper.Map(toUpdate, landLord);
        landLord.UpdatedAt = DateTime.Now;
        landLord.UpdatedBy = UpdatedBy;
        await _repo.Update(landLord);
    }
    public async Task Activate(Guid id, string UpdatedBy)
    {
        var landLord = await GetLandLord(id);
        
        ServiceException.When(landLord.Status == EntityStatusEnum.Active, $"Landlord already active. [Id={id}]");
        landLord.Status = EntityStatusEnum.Active;
        landLord.UpdatedAt = DateTime.Now;
        landLord.UpdatedBy = UpdatedBy;
        await _repo.Update(landLord);
    }
    public async Task Deactivate(Guid id, string UpdatedBy)
    {
        var landLord = await GetLandLord(id);
        
        ServiceException.When(landLord.Status == EntityStatusEnum.Inactive, $"Landlord already Inactive. [Id={id}]");
        landLord.Status = EntityStatusEnum.Inactive;
        landLord.UpdatedAt = DateTime.Now;
        landLord.UpdatedBy = UpdatedBy;
        await _repo.Update(landLord);
    }
    public async Task Delete(Guid id, string UpdatedBy)
    {
        var landLord = await GetLandLord(id);
        
        ServiceException.When(landLord.Status == EntityStatusEnum.Deleted, $"Landlord already Inactive. [Id={id}]");
        landLord.Status = EntityStatusEnum.Deleted;
        landLord.UpdatedAt = DateTime.Now;
        landLord.UpdatedBy = UpdatedBy;
        await _repo.Update(landLord);
    }
}