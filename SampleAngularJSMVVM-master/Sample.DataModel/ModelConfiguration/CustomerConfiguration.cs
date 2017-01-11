using Sample.Entities.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace Sample.DataModel.ModelConfiguration
{
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(x => x.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.MiddleName)
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.LastName)
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Address)
                .HasMaxLength(60)
                .IsOptional();

            Property(x => x.City)
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.State)
                .HasMaxLength(4)
                .IsOptional();

            Property(x => x.PostalCode)
                .HasMaxLength(20)
                .IsOptional();
        }
    }
}
