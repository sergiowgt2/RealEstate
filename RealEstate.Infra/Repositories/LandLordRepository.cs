using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Infra.Database;
using RealEstate.Infra.Repositories.Base;
using RealEstate.Service.Interfaces;

namespace RealEstate.Infra.Repositories;

public class LandLordRepository : NamedBaseEntityRepository<Landlord>, ILandLordRepository
{
    public LandLordRepository(ApplicationDbContext db) : base(db)
    {
    }
    
    public async Task<Landlord> GetByCpfCnpj(string cpfCnpj, Guid? excId)
    {
        Expression<Func<Landlord, bool>> condition;
        
        if (excId == null)
            condition = x => x.CNPJ_CPF == cpfCnpj && x.Status != EntityStatusEnum.Deleted;
        else 
            condition = x => x.CNPJ_CPF == cpfCnpj && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(condition);
    }

    public async Task<Landlord> GetByEmail(string email, Guid? excId)
    {
        Expression<Func<Landlord, bool>> condition;
        
        if (excId == null)
            condition = x => x.Email == email && x.Status != EntityStatusEnum.Deleted;
        else 
            condition = x => x.Email == email && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(condition);
    }

    public async Task<Landlord> GetByCellPhone(string cellPhone, Guid? excId)
    {
        Expression<Func<Landlord, bool>> condition;
        
        if (excId == null)
            condition = x => x.CellPhone == cellPhone && x.Status != EntityStatusEnum.Deleted;
        else 
            condition = x => x.CellPhone == cellPhone && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(condition);
    }
}