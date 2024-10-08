﻿using Microsoft.EntityFrameworkCore;
using Book_Store.ViewModels;
namespace Book_Store.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[] {
            new Category { Id = 1, Name = "Fiction" },
            new Category { Id = 2, Name = "Non-Fiction" },
            new Category { Id = 3, Name = "Science Fiction" },
            new Category { Id = 4, Name = "Biography" },
            new Category { Id = 5, Name = "Fantasy" },
            new Category { Id = 6, Name = "Mystery" },
            new Category { Id = 7, Name = "Romance" },
            new Category { Id = 8, Name = "Thriller" },
            new Category { Id = 9, Name = "Historical" },
            new Category { Id = 10, Name = "Horror" },
            new Category { Id = 11, Name = "Self-Help" },
            new Category { Id = 12, Name = "Health" },
            new Category { Id = 13, Name = "Travel" },
            new Category { Id = 14, Name = "Children's" },
            new Category { Id = 15, Name = "Cooking" },
            new Category { Id = 16, Name = "Art" },
            new Category { Id = 17, Name = "Photography" },
            new Category { Id = 18, Name = "Poetry" },
            new Category { Id = 19, Name = "Graphic Novels" },
            new Category { Id = 20, Name = "Adventure" },
            new Category { Id = 21, Name = "Science" },
            new Category { Id = 22, Name = "Education" },
            new Category { Id = 23, Name = "Religion" },
            new Category { Id = 24, Name = "Politics" },
            new Category { Id = 25, Name = "Technology" }
            }
);

            string[] roleNames = { "Admin", "User", "Manager" };

            // Seed roles
            foreach (var roleName in roleNames)
            {
                var role = new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper(),
                    Id = Guid.NewGuid().ToString()  // Generate unique GUIDs for each role
                };

                modelBuilder.Entity<IdentityRole>().HasData(role);
                modelBuilder.Entity<LoginViewModel>().HasNoKey();
                base.OnModelCreating(modelBuilder);

            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Hisham\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Book_Store.ViewModels.RegisterUserViewModel> RegisterUserViewModel { get; set; } = default!;
        public DbSet<Book_Store.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
    }
}
