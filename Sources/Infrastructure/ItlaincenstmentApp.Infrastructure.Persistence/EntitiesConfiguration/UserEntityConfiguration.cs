using ItlaincenstmentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItlaincenstmentApp.Infrastructure.Persistence.EntitiesConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            #region Basic Configuration
            builder.HasKey(x => x.Id);
            builder.ToTable("Users");
            #endregion

            #region Property Configurations
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);
            #endregion

            #region Relationships
            // configurar siempre desde el mucho
            builder.HasMany(u => u.InvestmentPorfolios)
                .WithOne(ip => ip.User)
                .HasForeignKey(ip => ip.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
