using ItlaincenstmentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItlaincenstmentApp.Infrastructure.Persistence.EntitiesConfiguration
{
    public class InvestmentPorfolioEntityConfiguration : IEntityTypeConfiguration<InvestmentPorfolio>
    {
        public void Configure(EntityTypeBuilder<InvestmentPorfolio> builder)
        {

            #region Basic Configuration
            builder.HasKey(x => x.Id);
            builder.ToTable("InvestmentPorfolios");
            #endregion

            #region Property Configurations
            builder.Property(ip => ip.Name)
                .IsRequired()
                .HasMaxLength(255);
            #endregion

            #region Relationships
                
            #endregion
        }
    }
}
