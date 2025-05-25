using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public AdminController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AdminStatisticsViewModel
            {
                TotalBooks = await _statisticsService.GetTotalBooksAsync(),
                TotalAuthors = await _statisticsService.GetTotalAuthorsAsync(),
                TotalGenres = await _statisticsService.GetTotalGenresAsync(),
                TotalUsers = await _statisticsService.GetTotalUsersAsync(),
                BorrowingsLastMonth = await _statisticsService.GetBorrowingsCountAsync(DateTime.Now.AddMonths(-1), DateTime.Now),
                BooksCountByGenre = await _statisticsService.GetBooksCountByGenreAsync(),
                TopBorrowedBooks = await _statisticsService.GetTopBorrowedBooksAsync(5),
                TopUsers = await _statisticsService.GetTopUsersAsync(5)
            };

            return View(model);
        }
    }
}
