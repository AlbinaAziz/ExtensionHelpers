using Microsoft.EntityFrameworkCore;
using System;

namespace Yampugo.API.Common.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=5.77.36.161;Initial Catalog=YampugoDBUat;User ID=sa;Password=supp0rt#Sumit; Max Pool Size=100");
        }
    }
}
