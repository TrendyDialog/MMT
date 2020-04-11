using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MMT.Domain.Models;
using MMT.Infra.Data.Extensions;
using MMT.Infra.Data.Mappings;
using System;
using System.IO;

namespace MMT.Infra.Data.Context
{
    public class MMTContext : DbContext
    {
        public DbSet<CellChanges>  CellChanges { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<DamageType> DamageTypes { get; set; }
        public DbSet<BagReplacement> BagReplacements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CellChangesMap());
            modelBuilder.AddConfiguration(new CellMap());
            modelBuilder.AddConfiguration(new DamageTypeMap());
            modelBuilder.AddConfiguration(new BagReplacementMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //// define the database to use
            optionsBuilder.UseLazyLoadingProxies();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("MyDbConnection"));
            }                
            else
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("MMTConnection"));
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
