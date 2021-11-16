using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpecificationDesignPattern.Logic.Movies;
public class MovieIEntityTypeConfiguration : IEntityTypeConfiguration<MovieEntity>
{
    public void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.ToTable("Movie");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(m => m.Name)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder
            .Property(e => e.ReleaseDate)
            .HasColumnType("datetimeoffset")
            .IsRequired();

        builder
            .Property(m => m.MpaaRating)
            .HasConversion<int>()
            .IsRequired();

        builder
            .Property(m => m.Genre)
            .HasMaxLength(20)
            .IsUnicode(false)
            .IsRequired();

        builder
            .Property(m => m.Rating)
            .IsRequired();

    }
}