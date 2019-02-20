using System;
using System.Collections.Generic;
using System.Text;
using bio_eko_fit_products_database.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace bio_eko_fit_products_database
{
    public class ProductsContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        private string _connectionString;

        public ProductsContext()
        {
        }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            _connectionString = options.GetExtension<NpgsqlOptionsExtension>()?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException(nameof(options));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=Products";
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
