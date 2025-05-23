using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DigitalLibrary.WebUI.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "Name");
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.AddAsync(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "Name", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name", book.GenreId);
            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "Name", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name", book.GenreId);
            return View(book);
        }

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

            ViewData["Authors"] = new SelectList(await _authorRepository.GetAllAsync(), "Id", "Name", book.AuthorId);
            ViewData["Genres"] = new SelectList(await _genreRepository.GetAllAsync(), "Id", "Name", book.GenreId);
            return View(book);
        }

    }
}

