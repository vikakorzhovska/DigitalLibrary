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
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index(string? title, int? authorId, int? genreId, int page = 1)
        {
            const int PageSize = 5;
            var model = await _bookService.GetBooksAsync(title, authorId, genreId, page, PageSize);

            ViewBag.Authors = await _bookService.GetAuthorsAsync();
            ViewBag.Genres = await _bookService.GetGenresAsync();
            ViewBag.SelectedAuthorId = authorId;
            ViewBag.SelectedGenreId = genreId;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewData["Authors"] = new SelectList(await _bookService.GetAuthorsAsync(), "Id", "FullName");
            ViewData["Genres"] = new SelectList(await _bookService.GetGenresAsync(), "Id", "Name");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddAsync(book);
                return RedirectToAction(nameof(Index));
            }

            ViewData["Authors"] = new SelectList(await _bookService.GetAuthorsAsync(), "Id", "FullName", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _bookService.GetGenresAsync(), "Id", "Name", book.GenreId);

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();

            ViewData["Authors"] = new SelectList(await _bookService.GetAuthorsAsync(), "Id", "FullName", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _bookService.GetGenresAsync(), "Id", "Name", book.GenreId);

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
                await _bookService.UpdateAsync(book);
                return RedirectToAction(nameof(Index));
            }

            ViewData["Authors"] = new SelectList(await _bookService.GetAuthorsAsync(), "Id", "FullName", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _bookService.GetGenresAsync(), "Id", "Name", book.GenreId);

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();

            return View(book);
        }
    }
}

