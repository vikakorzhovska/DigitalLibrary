using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.Models;
using DigitalLibrary.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IGenreRepository _genreRepo;

        public BookService(IBookRepository bookRepo, IAuthorRepository authorRepo, IGenreRepository genreRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _genreRepo = genreRepo;
        }

        public async Task<PaginationViewModel<Book>> GetBooksAsync(string? title, int? authorId, int? genreId, int page, int pageSize)
        {
            var books = (await _bookRepo.GetAllAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(title))
                books = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

            if (authorId.HasValue)
                books = books.Where(b => b.AuthorId == authorId.Value).ToList();

            if (genreId.HasValue)
                books = books.Where(b => b.GenreId == genreId.Value).ToList();

            var totalBooks = books.Count;
            var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);
            var pagedBooks = books.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PaginationViewModel<Book>
            {
                Items = pagedBooks,
                CurrentPage = page,
                TotalPages = totalPages,
                SearchTerm = title
            };
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync() => await _authorRepo.GetAllAsync();
        public async Task<IEnumerable<Genre>> GetGenresAsync() => await _genreRepo.GetAllAsync();
        public async Task<Book?> GetByIdAsync(int id) => await _bookRepo.GetByIdAsync(id);
        public async Task AddAsync(Book book) => await _bookRepo.AddAsync(book);
        public async Task UpdateAsync(Book book) => await _bookRepo.UpdateAsync(book);
        public async Task DeleteAsync(int id) => await _bookRepo.DeleteAsync(id);
    }
}
