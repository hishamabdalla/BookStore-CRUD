namespace Book_Store.Services
{
    public interface IBooksService
    {
        Task Create(CreateBookFormViewModel model);

    }
}
