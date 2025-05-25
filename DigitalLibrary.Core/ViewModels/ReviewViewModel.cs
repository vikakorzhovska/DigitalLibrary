using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.ViewModels
{
    public class ReviewViewModel
    {
        [Required]
        public string Comment { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; }

        public int BookId { get; set; }
    }
}
