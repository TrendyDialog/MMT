using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MMT.Domain.Core.Events;
using MMT.Infra.Data.Extensions;
using MMT.Infra.Data.Mappings;
using System.IO;

namespace MMT.Infra.Data.Context
{
    public class EventStoreContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(config.GetConnectionString("MMTConnection"));
        }
    }
}
