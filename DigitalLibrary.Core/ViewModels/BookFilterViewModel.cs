using DigitalLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.ViewModels
{
    public class BookFilterViewModel
    {
        public string? Title { get; set; }
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }

        public IEnumerable<Author>? Authors { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
        public IEnumerable<Book>? Books { get; set; }
    }
}
