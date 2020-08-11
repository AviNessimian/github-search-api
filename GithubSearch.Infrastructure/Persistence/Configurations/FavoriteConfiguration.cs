using GithubSearch.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GithubSearch.Infrastructure.Persistence.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<FavoriteEntity>
    {
        public void Configure(EntityTypeBuilder<FavoriteEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.CreatedBy)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.RepoFullName)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}


