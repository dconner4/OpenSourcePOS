using Microsoft.EntityFrameworkCore;
using Models;

namespace LocalRepository.Context
{
    public class LocalDatabaseContext : DbContext
    {
        private static readonly string localRepositoryPath = "openSourcePOS.db";

        /// <summary>
        /// Configure the Data Context with a SQLite database
        /// </summary>
        /// <param name="optionsBuilder">The options to configure the Data Context with</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source = {localRepositoryPath}",
                    x => x.MigrationsAssembly("LocalRepository"));
            }
        }

        /// <summary>
        /// The set of <see cref="SaleItem"/> to query off of
        /// </summary>
        public DbSet<SaleItem> SalesItems { get; set; }

        /// <summary>
        /// The set of <see cref="InventoryItem"/> to query off of
        /// </summary>
        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}
