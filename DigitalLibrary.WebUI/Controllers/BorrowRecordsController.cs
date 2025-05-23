using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DigitalLibrary.WebUI.Controllers
{
    public class BorrowRecordsController : Controller
    {
        private readonly IBorrowRecordRepository _borrowRecordRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IUserRepository _userRepo;

        public BorrowRecordsController(
            IBorrowRecordRepository borrowRecordRepo,
            IBookRepository bookRepo,
            IUserRepository userRepo)
        {
            _borrowRecordRepo = borrowRecordRepo;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _borrowRecordRepo.GetAllAsync();
            return View(records);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Books = new SelectList(await _bookRepo.GetAllAsync(), "Id", "Title");
            ViewBag.Users = new SelectList(await _userRepo.GetAllAsync(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BorrowRecord record)
        {
            if (record.ReturnedAt != null && record.ReturnedAt < record.BorrowedAt)
            {
                ModelState.AddModelError("ReturnedAt", "Дата повернення не може бути раніше дати видачі.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Books = new SelectList(await _bookRepo.GetAllAsync(), "Id", "Title");
                ViewBag.Users = new SelectList(await _userRepo.GetAllAsync(), "Id", "FullName");
                return View(record);
            }

            await _borrowRecordRepo.AddAsync(record);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var record = await _borrowRecordRepo.GetByIdAsync(id);
            if (record == null) return NotFound();
            return View(record);
        }
    }
}
