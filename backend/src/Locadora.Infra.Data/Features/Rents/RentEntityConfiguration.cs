using Locadora.Domain.Features.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Features.Rents
{
    public class RentEntityConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.CreateAt).IsRequired();
            builder.Property(r => r.UpdateAt).IsRequired();
            builder.Property(r => r.CustomerCpf).HasMaxLength(14).IsRequired();
        }
    }
}
