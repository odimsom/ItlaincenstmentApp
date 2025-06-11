using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ItlaincenstmentApp.Infrastructure.Persistence.Context
{
    public class InvestmentAppContext : DbContext
    {
        public InvestmentAppContext(DbContextOptions<InvestmentAppContext> options) : base(options) {}

        #region Dbsets
        public DbSet<UserRepository> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetHistoryRepositry> AssetHistories { get; set; }
        public DbSet<InvestmentPorfolioRepository> InvestmentPorfolios { get; set; }
        public DbSet<InvestmentAssets> InvestmentAssets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//Liskov-substitution
            #region Add Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion
        }
    }
}
