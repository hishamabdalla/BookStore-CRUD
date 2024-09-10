
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
            var books = _booksService.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {

            var book= _booksService.GetById(id);
            if(book is null)
                return NotFound();
            return View(book);
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
           var book= _booksService.GetById(id);
            if(book is null)
            {
                return NotFound();
            }
            EditBookFormViewModel viewModel = new EditBookFormViewModel()
            {
                id = id,
                Title = book.Title,
                Description = book.Description,
                CategoryId = book.CategoryId,
                Price = book.Price,
                Categories = _cateoriesService.GetSelectList(),
                CurrentCover= book.Cover

            };
            return View(viewModel); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(EditBookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _cateoriesService.GetSelectList();
                return View(model);
            }
            var book= await _booksService.Update(model);
            if(book is null)
            {
                
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var isDeleted = _booksService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
