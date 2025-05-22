using DigitalLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.WebUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAllAsync();
            return View(books);
        }
    }
}
