using Locadora.Domain.Features.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Features.Genres
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(100).IsRequired();
            builder.Property(g => g.CreateAt).IsRequired();
            builder.Property(g => g.UpdateAt).IsRequired();
            builder.Property(g => g.Active).IsRequired();
            builder.Property(g => g.IsRemoved).IsRequired();

            builder.HasMany(g => g.Movies).WithOne(m => m.Genre);
        }
    }
}
