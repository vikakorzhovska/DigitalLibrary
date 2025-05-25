using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.Models;
using DigitalLibrary.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalLibrary.WebUI.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;

        public ReviewController(IReviewRepository reviewRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid data.";
                return RedirectToAction("Details", "Books", new { id = model.BookId });
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var review = new Review
            {
                Comment = model.Comment,
                Rating = model.Rating,
                BookId = model.BookId,
                UserId = userId
            };

            await _reviewRepository.AddAsync(review);
            return RedirectToAction("Details", "Books", new { id = model.BookId });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, int bookId)
        {
            await _reviewRepository.DeleteAsync(id);
            return RedirectToAction("Details", "Books", new { id = bookId });
        }
    }
}
