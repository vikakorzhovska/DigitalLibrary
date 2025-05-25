using DigitalLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.ViewModels
{
    public class AuthorsFilterViewModel
    {
        public string? Name { get; set; }
        public IEnumerable<Author>? Authors { get; set; }
    }
}
