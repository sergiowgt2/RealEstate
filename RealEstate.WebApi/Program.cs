using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infra.Database;
using RealEstate.Infra.Repositories;
using RealEstate.Service.Interfaces;
using RealEstate.Service.Model;
using RealEstate.Service.Services;
using RealEstate.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false);
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
var mapper = mapperConfig.CreateMapper();

builder.Services.AddScoped<ILandLordRepository, LandLordRepository>();
builder.Services.AddScoped<LandLordService>();
builder.Services.AddSingleton<IMapper>(mapper);

var app = builder.Build();
var landLordInsertModel = new LandlordInsertModel()
{
    Name = "Pedro2",
    Email = "pedro2@gmail.com",
    CellPhone = "Cellphone2",
    CpfCnpj = "Cpf"
};

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var service = services.GetRequiredService<LandLordService>();
    await service.Insert(landLordInsertModel, "Sergio");
}

//app.MapGet("/", () => "Hello World!");
app.Run();



// dotnet ef migrations add InitialCreate --verbose --project RealEstate.infra --startup-project RealEstate.WebApi
//  dotnet ef database update --verbose --project RealEstate.infra --startup-project RealEstate.WebApi
// donet ef database update InitialCreate --verbose --project dentalRJ.infra --startup-project RJDental.WebApp
// dotnet ef migrations remove InitialCreate --verbose --project dentalRJ.infra --startup-project RJDental.WebApp
// dotnet ef database update 0  --verbose --project dentalRJ.infra --startup-project RJDental.WebApp



