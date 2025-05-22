using DigitalLibrary.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.WebUI.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetAllAsync();
            return View(genres);
        }
    }
}
