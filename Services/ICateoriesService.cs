namespace Book_Store.Services
{
    public interface ICateoriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
