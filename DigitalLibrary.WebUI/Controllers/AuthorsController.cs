using DigitalLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.WebUI.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepository.GetAllAsync();
            return View(authors);
        }
    }
}
