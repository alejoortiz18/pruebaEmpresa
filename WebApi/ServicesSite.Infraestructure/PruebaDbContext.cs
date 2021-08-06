using Microsoft.EntityFrameworkCore;
using ServicesSite.Domain;
using ServicesSite.Domain.Entities;
using System;

namespace ServicesSite.Infraestructure
{
    public class PruebaDbContext : DbContext
    {
        private readonly string _connection;

        public PruebaDbContext(string connection)
        {
            _connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public virtual DbSet<ClienteE> ClienteEs { get; set; }
    }
  
}
