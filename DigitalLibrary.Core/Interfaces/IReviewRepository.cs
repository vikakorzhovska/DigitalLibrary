using DigitalLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetByBookIdAsync(int bookId);
        Task AddAsync(Review review);
        Task DeleteAsync(int id);
    }
}
