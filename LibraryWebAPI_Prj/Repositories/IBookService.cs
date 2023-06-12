using LibraryWebAPI_Prj.Entities;

namespace LibraryWebAPI_Prj.Repositories
{
    public interface IBookService
    {
        public Task<List<Books>> GetBookListAsync();
        public Task<IEnumerable<Books>> GetBookByIdAsync(int Id);
        public Task<int> AddBookAsync(Books Book);
        public Task<int> UpdateBookAsync(Books Book);
        public Task<int> DeleteBookAsync(int Id);

    }
}
