using Locadora.Domain.Features.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Features.Movies
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(200).IsRequired();
            builder.Property(m => m.CreateAt).IsRequired();
            builder.Property(m => m.UpdateAt).IsRequired();
            builder.Property(m => m.Active).IsRequired();
            builder.Property(m => m.IsRemoved).IsRequired();

            builder.Property(m => m.GenreId).IsRequired();
            builder.HasOne(m => m.Genre).WithMany(g => g.Movies);
        }
    }
}
