using System.Diagnostics;

namespace Book_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksService _booksService;

        public HomeController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public IActionResult Index()
        {
            var books = _booksService.GetAll();
            return View(books);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
