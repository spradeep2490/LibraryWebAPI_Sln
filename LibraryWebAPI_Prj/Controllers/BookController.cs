using LibraryWebAPI_Prj.Entities;
using LibraryWebAPI_Prj.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI_Prj.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("getbookslist")]
        public async Task<List<Books>> GetBooksListAsync()
        {
            try
            {
                return await bookService.GetBookListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getbookbyid")]
        public async Task<IEnumerable<Books>> GetBookByIdAsync(int Id)
        {
            try
            {
                var response = await bookService.GetBookByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addbook")]
        public async Task<IActionResult> AddBookAsync(Books book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await bookService.AddBookAsync(book);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatebook")]
        public async Task<IActionResult> UpdateBookAsync(Books book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await bookService.UpdateBookAsync(book);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deletebook")]
        public async Task<int> DeleteBookAsync(int Id)
        {
            try
            {
                var response = await bookService.DeleteBookAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }

    }
}
