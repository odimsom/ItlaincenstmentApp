using ItlaincenstmentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItlaincenstmentApp.Infrastructure.Persistence.EntitiesConfiguration
{
    public class AssetEntityConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            #region Basic Configuration
            builder.HasKey(x => x.Id);
            builder.ToTable("Assets");
            #endregion

            #region Property Configurations
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(a => a.Symbol)
                .IsRequired()
                .HasMaxLength(20);
            #endregion

            #region Relationships
            builder.HasMany(a => a.AssetHistories)
                .WithOne(ah => ah.Asset)
                .HasForeignKey(ah => ah.AssetId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
