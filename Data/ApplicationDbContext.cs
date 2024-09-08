
using Book_Store.Models;

namespace Book_Store.Data
{
    public class ApplicationDbContext:DbContext
    {
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

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Hisham\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
