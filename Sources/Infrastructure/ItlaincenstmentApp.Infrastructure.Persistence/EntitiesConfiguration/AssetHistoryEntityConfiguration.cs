using ItlaincenstmentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItlaincenstmentApp.Infrastructure.Persistence.EntitiesConfiguration
{
    public class AssetHistoryEntityConfiguration : IEntityTypeConfiguration<AssetHistory>
    {
        public void Configure(EntityTypeBuilder<AssetHistory> builder)
        {
            #region Basic Configuration
            builder.HasKey(x => x.Id);
            builder.ToTable("AssetHistorys");
            #endregion

            #region Property Configurations
            builder.Property(ah => ah.Value)
                .IsRequired()
                .HasDefaultValue(0)
                .HasPrecision(18, 4); ;
            #endregion
        }
    }
}
