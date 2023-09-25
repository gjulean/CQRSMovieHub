using CQRSMovieHub.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRSMovieHub.Queries.DataAccess.Implementations.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movie");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName("Id")
            .IsRequired(true)
            .ValueGeneratedOnAdd();

        builder.Property(m => m.Name)
            .HasColumnName("Name")
            .IsRequired(true);

        builder.Property(m => m.Genre)
            .HasColumnName("Genre")
            .IsRequired(true);

        builder.Property(m => m.FilmedAt)
            .HasColumnName("FilmedAt")
            .IsRequired(true);

        builder.Property(m => m.DirectorId)
            .HasColumnName("DirectorId")
            .IsRequired(true);

        builder.HasOne(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey(m => m.DirectorId);

    }
}
