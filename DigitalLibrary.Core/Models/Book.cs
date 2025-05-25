using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.Models
{
    public class Book : BaseEntity
    {
        [Required(ErrorMessage = "Назва обов'язкова")]
        [StringLength(150)]
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Year { get; set; }
        [Required(ErrorMessage = "Автор обов'язковий")]
        public int AuthorId { get; set; }
        public Author ?Author { get; set; } 
        [Required(ErrorMessage = "Жанр обов'язковий")]
        public int GenreId { get; set; }
        public Genre ?Genre { get; set; } 

        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
