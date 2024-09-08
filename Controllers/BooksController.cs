
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
           

            CreateBookFormViewModel Vm = new CreateBookFormViewModel()
            {
                Categories = _context.categories.Select(c=>new SelectListItem{Value=c.Id.ToString(), Text =c.Name }).ToList()
            };
            return View(Vm);
        }
    }
}
