namespace Book_Store.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Task Create(CreateBookFormViewModel model);
        void Update(CreateBookFormViewModel model);
        void Delete(int id);

    }
}
