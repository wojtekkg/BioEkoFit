using System;
using System.Collections.Generic;
using System.Text;
using bio_eko_fit_database.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace bio_eko_fit_database
{
    class BioEkoFitContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<StepEntity> Steps { get; set; }
        public DbSet<ProductForDishEntity> ProductsForDishes { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<DishForMenuEntity> DishesForMenus { get; set; }
        private string _connectionString;

        public BioEkoFitContext(DbContextOptions<BioEkoFitContext> options) : base(options)
        {
            
            _connectionString = options.GetExtension<NpgsqlOptionsExtension>()?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException(nameof(options));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=BioEkoFit";
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
