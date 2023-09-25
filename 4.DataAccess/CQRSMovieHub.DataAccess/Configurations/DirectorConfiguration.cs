using CQRSMovieHub.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRSMovieHub.Queries.DataAccess.Implementations.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("director");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasColumnName("Id")
            .IsRequired(true)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Name)
            .HasColumnName("Name")
            .IsRequired();

        builder.HasMany(director => director.Movies)
                 .WithOne(director => director.Director)
                 .HasForeignKey(director => director.DirectorId);
    }
}
