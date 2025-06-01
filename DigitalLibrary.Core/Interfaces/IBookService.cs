using DigitalLibrary.Core.Models;
using DigitalLibrary.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.Interfaces
{
    public interface IBookService
    {
        Task<PaginationViewModel<Book>> GetBooksAsync(string? title, int? authorId, int? genreId, int page, int pageSize);
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
