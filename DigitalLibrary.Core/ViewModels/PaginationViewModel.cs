using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.ViewModels
{
    public class PaginationViewModel<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? SearchTerm { get; set; }
    }
}
