using Sample.DataModel.ModelConfiguration;
using Sample.Entities.Data.Models;
using System.Data.Entity;

namespace Sample.DataModel
{
    // You may need to enable Migrations. This is the command:
    // Enable-Migrations -ContextProjectName:Sample.DataModel -ContextTypeName:Sample.DataModel.MssqlDataContext -MigrationsDirectory:Migrations.MssqlDB -ProjectName:Sample.DataModel
    // This will create the first migration of the database
    // Add-Migration InitialCreate -ProjectName:Sample.DataModel
    // This command will create the database and seed the default data
    // Update-Database -ProjectName:Sample.DataModel -configuration Sample.DataModel.Migrations.MssqlDB.Configuration
    
    // TO ADD A NEW MIGRATIONS:
    // Add-Migration MigrationSetNameGoesHere -ProjectName:Sample.DataModel -configuration Sample.DataModel.Migrations.MssqlDB.Configuration

    public class MssqlDataContext : DbContext
    {
        public MssqlDataContext() : base("MssqlDataContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Configurations.Add(new CustomerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
