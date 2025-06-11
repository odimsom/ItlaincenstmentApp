using ItlaincenstmentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItlaincenstmentApp.Infrastructure.Persistence.EntitiesConfiguration
{
    public class AssetTypeEntityConfiguration : IEntityTypeConfiguration<AssetType>
    {
        public void Configure(EntityTypeBuilder<AssetType> builder)
        {
            #region Basic Configuration
            builder.HasKey(x => x.Id);
            builder.ToTable("AssetTypes");
            #endregion

            #region Property Configurations
            builder.Property(at => at.Name)
                .IsRequired()
                .HasMaxLength(255);
            #endregion

            #region Relationships
            builder.HasMany(at => at.Assets)
                .WithOne(a => a.AssetType)
                .HasForeignKey(at => at.AssetTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
