using ItlaincenstmentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItlaincenstmentApp.Infrastructure.Persistence.EntitiesConfiguration
{
    public class InvestmentAssetsEntityConfiguration : IEntityTypeConfiguration<InvestmentAssets>
    {
        public void Configure(EntityTypeBuilder<InvestmentAssets> builder)
        {
            #region Basic Configuration
            builder.HasKey(x => new {x.AssetId, x.InvestmentPorfolioId});
            builder.ToTable("InvestmentAssets");
            #endregion

            #region Property Configurations
            #endregion

            #region Relationships

            builder.HasOne(ia => ia.Assets)
                .WithMany(a => a.InvestmentAssets)
                .HasForeignKey(ia => ia.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ia => ia.InvestmentPorfolio)
                .WithMany(ip => ip.InvestmentAssets)
                .HasForeignKey(ia => ia.InvestmentPorfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
