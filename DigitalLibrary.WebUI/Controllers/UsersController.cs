using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.Models;
using DigitalLibrary.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using DigitalLibrary.Core.Services;
using DigitalLibrary.Core.ViewModels;
namespace DigitalLibrary.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly PasswordHasher _passwordHasher;
        public UsersController(IUserRepository userRepo, PasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepo.GetAllAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = _passwordHasher.HashPassword(model.Password)
            };

            await _userRepo.AddAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, User userFromForm, string? newPassword)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.Username = userFromForm.Username;
            user.Email = userFromForm.Email;

            if (!string.IsNullOrEmpty(newPassword))
            {
                user.PasswordHash = _passwordHasher.HashPassword(newPassword);
            }

            await _userRepo.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
