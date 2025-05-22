using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Infrastructure.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        private readonly LibraryDbContext _context;

        public BorrowRecordRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BorrowRecord>> GetAllAsync()
        {
            return await _context.BorrowRecords
                .Include(r => r.Book)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<BorrowRecord?> GetByIdAsync(int id)
        {
            return await _context.BorrowRecords
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(BorrowRecord record)
        {
            _context.BorrowRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BorrowRecord record)
        {
            _context.BorrowRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _context.BorrowRecords.FindAsync(id);
            if (record != null)
            {
                _context.BorrowRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
