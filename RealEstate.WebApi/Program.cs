using Microsoft.EntityFrameworkCore;
using RealEstate.Infra.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Adicione a configuração do banco de dados ao seu aplicativo

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<DentistTypeRepository>();
//builder.Services.AddScoped<SpecialtyTypeRepository>();
//builder.Services.AddScoped<DentistRepository>();

var app = builder.Build();

/*
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