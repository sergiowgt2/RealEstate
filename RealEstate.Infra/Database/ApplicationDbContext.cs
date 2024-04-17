using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.Domain.Entities;

namespace RealEstate.Infra.Database;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Landlord> Landlord { get; set; }
    public DbSet<LeaseContract> LeaseContract { get; set; }
    public DbSet<RentalProperty> RentalProperty { get; set; }
    public DbSet<Tenant> Tenant { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configure a conexão com o PostgreSQL aqui
            optionsBuilder.UseMySQL("Server=pstgs-backoffice-flex-homolog.postgres.database.azure.com;Port=3006;Database=homologcmo;User Id=manutencao;Password=Fa23wq35QtqpS!NP;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}