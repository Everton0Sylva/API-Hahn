using API.Domain.Entities;
using API.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public IConfiguration configuration;
        public MySqlContext(DbContextOptions<MySqlContext> options, IConfiguration config) : base(options)
        {
            configuration = config;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            var server = configuration["database:mysql:server"];
            var port = configuration["database:mysql:port"];
            var database = configuration["database:mysql:database"];
            var username = configuration["database:mysql:username"];
            var password = configuration["database:mysql:password"];

            optionsBuilder.UseMySql($"Server={server};Port={port};Database={database};Uid={username};Pwd={password}",
            new MySqlServerVersion(new Version(8, 0, 36))
            );
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
