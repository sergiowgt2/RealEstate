using RealEstate.Service.Model.Base;

namespace RealEstate.Service.Model;

public class TenantInsertModel : BaseModel 
{
    public string CnpjCpf { get; set; }
    public string CellPhone { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}