using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.Models
{
    public class BookBorrowCount
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class UserBorrowCount
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Count { get; set; }
    }

}
