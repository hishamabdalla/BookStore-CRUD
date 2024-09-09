namespace Book_Store.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        Task Create(CreateBookFormViewModel model);
        Task<Book?> Update(EditBookFormViewModel model);
        bool Delete(int id);


    }
}
