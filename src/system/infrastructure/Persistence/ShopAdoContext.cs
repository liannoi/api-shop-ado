using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Infrastructure.Persistence
{
    public class ShopAdoContext : DbContext, IShopAdoContext
    {
        private IDbContextTransaction _currentTransaction;

        public ShopAdoContext(DbContextOptions<ShopAdoContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Good> Good { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SalePos> SalePos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopAdoContext).Assembly);
        }

        #region Work with transactions (implementation of Unit of Work pattern).

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null) return;

            _currentTransaction = await base.Database
                .BeginTransactionAsync(IsolationLevel.ReadCommitted)
                .ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        #endregion
    }
}