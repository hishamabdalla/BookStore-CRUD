
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
            _imagesPath=$"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.books
                .Include(b=>b.Category)
                .AsNoTracking()
                .ToList();
        }
        public Book? GetById(int id)
        {
            return _context.books
                .Include(b=>b.Category)
                .AsNoTracking()
                .SingleOrDefault(b => b.Id == id);
        }
        public async Task Create(CreateBookFormViewModel model)
        {
            var coverName = await SaveCover(model.Cover);
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
        public async Task<Book?> Update(EditBookFormViewModel model)
        {
            var book = _context.books.FirstOrDefault(b=>b.Id==model.id);
            if(book == null)
                return null;
            var hasNewCover = model.Cover is not null;
            var oldCover=book.Cover;

            book.Title = model.Title;
            book.Price = model.Price;
            book.CategoryId = model.CategoryId;
            book.Description= model.Description;

            if (hasNewCover)
            {
                book.Cover=await SaveCover(model.Cover);
            }
           var effectedRows= _context.SaveChanges();

            if (effectedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagesPath, oldCover);
                    File.Delete(cover);
                }
                return book;
            }
            else
            {
                var cover = Path.Combine(_imagesPath, book.Cover);
                File.Delete(cover);
                return null;
            }
        }   
        public bool Delete(int id)
        {
            var isDeleted = false;

            var book=_context.books.FirstOrDefault(a=>a.Id==id);
            if (book is null)
                return isDeleted;

            _context.books.Remove(book);
            var effectedRows=_context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
                var cover =Path.Combine(_imagesPath, book.Cover);
            }
            return isDeleted;
        }

        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return coverName;

        }
    }
   
}
