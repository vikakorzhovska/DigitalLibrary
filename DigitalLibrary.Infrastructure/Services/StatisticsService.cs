using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Infrastructure.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly LibraryDbContext _context;

        public StatisticsService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalBooksAsync()
        {
            return await _context.Books.CountAsync();
        }

        public async Task<int> GetTotalAuthorsAsync()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<int> GetTotalGenresAsync()
        {
            return await _context.Genres.CountAsync();
        }

        public async Task<int> GetTotalUsersAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> GetBorrowingsCountAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.BorrowRecords
                .Where(br => br.BorrowedAt >= fromDate && br.BorrowedAt <= toDate)
                .CountAsync();
        }

        public async Task<IEnumerable<BookBorrowCount>> GetTopBorrowedBooksAsync(int topCount)
        {
            return await _context.BorrowRecords
                .Include(br => br.Book)
                .GroupBy(br => new { br.BookId, br.Book.Title })
                .Select(g => new BookBorrowCount
                {
                    BookId = g.Key.BookId,
                    BookTitle = g.Key.Title,
                    Count = g.Count()
                })
                .OrderByDescending(bc => bc.Count)
                .Take(topCount)
                .ToListAsync();
        }


        public async Task<IEnumerable<UserBorrowCount>> GetTopUsersAsync(int topCount)
        {
            return await _context.BorrowRecords
                .Include(br => br.User)
                .GroupBy(br => new { br.UserId, br.User.Username })
                .Select(g => new UserBorrowCount
                {
                    UserId = g.Key.UserId,
                    UserName = g.Key.Username,
                    Count = g.Count()
                })
                .OrderByDescending(uc => uc.Count)
                .Take(topCount)
                .ToListAsync();
        }


        public async Task<Dictionary<string, int>> GetBooksCountByGenreAsync()
        {
            return await _context.Books
                .GroupBy(b => b.Genre.Name)
                .Select(g => new { GenreName = g.Key, Count = g.Count() })
                .ToDictionaryAsync(g => g.GenreName, g => g.Count);
        }
    }
}
