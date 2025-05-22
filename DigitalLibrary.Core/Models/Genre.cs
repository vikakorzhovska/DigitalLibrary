using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
