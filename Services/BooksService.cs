
using Book_Store.Models;

namespace Book_Store.Services
{
    public class BooksService:IBooksService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public BooksService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath=$"{_webHostEnvironment.WebRootPath}/assets/Images/Books";
        }

        public async Task Create(CreateBookFormViewModel model)
        {
            var coverName=$"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var paht = Path.Combine(_imagesPath, coverName);

            using var stream=File.Create(paht);
            await model.Cover.CopyToAsync(stream);
            Book book = new Book()
            {
                Title = model.Title,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Cover=coverName,
                Description=model.Description,
               
            };
            _context.books.Add(book);
            _context.SaveChanges();
            
        }
    }
}
