using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Models
{
    public class GameDbContext:IdentityDbContext<IdentityUser>
    {
        public GameDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Shooter", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "Fighting", });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "Open World", });

            modelBuilder.Entity<Game>().HasData(new Game { Id = 1, Name = "GTA V", Price = 50, CategoryId = 1 });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 2, Name = "COD", Price = 10, CategoryId = 2 });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 3, Name = "Tekken", Price = 150, CategoryId = 3 });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 4, Name = "Snow Bros", Price = 5, CategoryId = 1 });

        }
    }
}
