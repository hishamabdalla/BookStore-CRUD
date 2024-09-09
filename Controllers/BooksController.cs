
using Book_Store.Services;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
        private readonly ICateoriesService _cateoriesService;

        public BooksController(IBooksService booksService,ICateoriesService cateoriesService)
        {
            this._booksService = booksService;
            this._cateoriesService = cateoriesService;
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
                Categories = _cateoriesService.GetSelectList()
            };
            return View(Vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookFormViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                model.Categories = _cateoriesService.GetSelectList();
                return View(model);
            }
            //save Books to database
            //save cover to server
           await _booksService.Create(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
