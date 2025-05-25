using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.Core.Models;


namespace DigitalLibrary.Core.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetTotalBooksAsync();
        Task<int> GetTotalAuthorsAsync();
        Task<int> GetTotalGenresAsync();
        Task<int> GetTotalUsersAsync();
        Task<int> GetBorrowingsCountAsync(DateTime fromDate, DateTime toDate);
        Task<IEnumerable<BookBorrowCount>> GetTopBorrowedBooksAsync(int topCount);
        Task<IEnumerable<UserBorrowCount>> GetTopUsersAsync(int topCount);
        Task<Dictionary<string, int>> GetBooksCountByGenreAsync();
    }

}
