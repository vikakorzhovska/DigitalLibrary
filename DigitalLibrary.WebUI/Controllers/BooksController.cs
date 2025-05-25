using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.Models;
using DigitalLibrary.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.WebUI.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;

        public BooksController(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index(string? title, int? authorId, int? genreId, int page = 1)
        {
            const int PageSize = 5;
            var books = (await _bookRepository.GetAllAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(title))
                books = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

            if (authorId.HasValue)
                books = books.Where(b => b.AuthorId == authorId.Value).ToList();

            if (genreId.HasValue)
                books = books.Where(b => b.GenreId == genreId.Value).ToList();

            var totalBooks = books.Count;
            var totalPages = (int)Math.Ceiling(totalBooks / (double)PageSize);

            var pagedBooks = books
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var paginationModel = new PaginationViewModel<Book>
            {
                Items = pagedBooks,
                CurrentPage = page,
                TotalPages = totalPages,
                SearchTerm = title
            };

            ViewBag.Authors = await _authorRepository.GetAllAsync();
            ViewBag.Genres = await _genreRepository.GetAllAsync();
            ViewBag.SelectedAuthorId = authorId;
            ViewBag.SelectedGenreId = genreId;

            return View(paginationModel);
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "FullName");
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name"); 

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.AddAsync(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "FullName", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name", book.GenreId);

            return View(book);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "FullName", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name", book.GenreId);

            return View(book);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _bookRepository.UpdateAsync(book);
                return RedirectToAction(nameof(Index));
            }

            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "FullName", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name", book.GenreId);

            return View(book);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }



    }
}

