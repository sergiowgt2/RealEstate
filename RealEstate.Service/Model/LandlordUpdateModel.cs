using RealEstate.Service.Model.Base;

namespace RealEstate.Service.Model;

public class LandlordUpdateModel : BaseModel
{
    public Guid Id { get; set; }
    public string CpfCnpj { get; set; }
    public string CellPhone { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}