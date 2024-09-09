
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Services
{
    public class CateoriesService : ICateoriesService
    {
        private readonly ApplicationDbContext _context;

        public CateoriesService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
          return  _context.categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(x => x.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
