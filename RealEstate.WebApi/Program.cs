using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Entities.Base;
using RealEstate.Infra.Database;
using RealEstate.Infra.Repositories;
using RealEstate.Infra.Repositories.Base;
using RealEstate.Service.Interfaces;
using RealEstate.Service.Model;
using RealEstate.Service.Model.Base;
using RealEstate.Service.Services;
using RealEstate.Service.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Adicione a configuração do banco de dados ao seu aplicativo

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddScoped<IBaseEntityRepository<BaseEntity>, BaseEntityRepository<BaseEntity>>();
//builder.Services.AddScoped<INamedBaseEntityRepository<NamedBaseEntity>, NamedBaseEntityRepository<NamedBaseEntity>>();
//builder.Services.AddScoped<LandLordRepository>();
//builder.Services.AddScoped<IBaseService<BaseEntity, BaseModel>,BaseService<BaseEntity, BaseModel>>();
//builder.Services.AddScoped<LandLordService>();

var app = builder.Build();
var landLordInsertModel = new LandLordInsertModel()
{
    Name = "Pedro",
    Email = "pedro@gmail.com",
    CellPhone = "Cellphone",
    CpfCnpj = "Cpf",
    CreatedBy = "Sergio"
};

var tenantInserModel = new TenantInsertModel()
{    
    Name = "Pedro",
    Email = "pedro@gmail.com",
    CellPhone = "Cellphone",
    CpfCnpj = "Cpf",
    CreatedBy = "Sergio"
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var repo = new LandLordRepository(context);
    var service = new LandLordService(repo);
    await service.Add(landLordInsertModel);
}


/*
var landLord = new Landlord
{
    Id = new Guid(),
    CellPhone = "CellPhone",
    CpfCnpj = "CpfCnpj",
    Name = "Name",
    Email = "sergio@gmail.com",
    CreatedAt = DateTime.Now,
    CreatedBy = "Sergio"
};
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var _repo = services.GetRequiredService<LandLordRepository>();
    await _repo.Add(landLord);
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Obtenha uma instância do seu repositório
        var repository = services.GetRequiredService<DentistRepository>();

        // Chame o método GetAll
        var objs = await repository.GetAll();

        // Faça algo com os dados obtidos
        foreach (var obj in objs)
        {
            Console.WriteLine($"Dentist: {obj.Cpf}");
        }
        // Obtenha uma instância do seu repositório
        var repository2 = services.GetRequiredService<DentistTypeRepository>();

        // Chame o método GetAll
        var dentists = await repository2.GetAll();

        // Faça algo com os dados obtidos
        foreach (var dentist in dentists)
        {
            Console.WriteLine($"Dentista: {dentist}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocorreu um erro ao obter os dados do repositório: " + ex.Message);
    }
}
*/

// Rota padrão
//app.MapGet("/", () => "Hello World!");
app.Run();



// dotnet ef migrations add InitialCreate --verbose --project RealEstate.infra --startup-project RealEstate.WebApi
//  dotnet ef database update --verbose --project RealEstate.infra --startup-project RealEstate.WebApi
// donet ef database update InitialCreate --verbose --project dentalRJ.infra --startup-project RJDental.WebApp
// dotnet ef migrations remove InitialCreate --verbose --project dentalRJ.infra --startup-project RJDental.WebApp
// dotnet ef database update 0  --verbose --project dentalRJ.infra --startup-project RJDental.WebApp



