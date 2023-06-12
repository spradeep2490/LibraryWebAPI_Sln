using LibraryWebAPI_Prj.Data;
using LibraryWebAPI_Prj.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI_Prj.Repositories
{
    public class BookService : IBookService
    {
        private readonly DbContextClass _dbContext;

        public BookService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Books>> GetBookByIdAsync(int BookId)
        {
            var param = new SqlParameter("@BookId", BookId);

            var bookDetails = await Task.Run(() => _dbContext.Books
                            .FromSqlRaw(@"exec GetBookByID @BookId", param).ToListAsync());

            return bookDetails;
        }

        public async Task<int> AddBookAsync(Books book)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@BookName", book.BookName));
            parameter.Add(new SqlParameter("@AuthorName", book.AuthorName));
            parameter.Add(new SqlParameter("@Price", book.Price));
            parameter.Add(new SqlParameter("@RackCode", book.RackCode));
            parameter.Add(new SqlParameter("@ShelfCode", book.ShelfCode));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewBook @BookName, @AuthorName, @Price, @RackCode, @ShelfCode" ,parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateBookAsync(Books book)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@BookId", book.Code));
            parameter.Add(new SqlParameter("@BookName", book.BookName));
            parameter.Add(new SqlParameter("@AuthorName", book.AuthorName));
            parameter.Add(new SqlParameter("@IS_Available", book.Is_Available));
            parameter.Add(new SqlParameter("@Price", book.Price));
            parameter.Add(new SqlParameter("@RackCode", book.RackCode));
            parameter.Add(new SqlParameter("@ShelfCode", book.ShelfCode));
            

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateBook @BookId,@BookName, @AuthorName, @IS_Available, @Price, @RackCode, @ShelfCode", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteBookAsync(int BookId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteBookByID {BookId}"));
        }
        public async Task<List<Books>> GetBookListAsync()
        {
            return await _dbContext.Books
                .FromSqlRaw<Books>("GetBooksList")
                .ToListAsync();
        }

    }
}
