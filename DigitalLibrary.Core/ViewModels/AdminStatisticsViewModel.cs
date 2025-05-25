using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.Core.Models;
namespace DigitalLibrary.Core.ViewModels
{
    public class AdminStatisticsViewModel
    {
        public int TotalBooks { get; set; }
        public int TotalAuthors { get; set; }
        public int TotalGenres { get; set; }
        public int TotalUsers { get; set; }
        public int BorrowingsLastMonth { get; set; }
        public Dictionary<string, int> BooksCountByGenre { get; set; } = new();
        public IEnumerable<BookBorrowCount> TopBorrowedBooks { get; set; } = new List<BookBorrowCount>();
        public IEnumerable<UserBorrowCount> TopUsers { get; set; } = new List<UserBorrowCount>();
    }

}
