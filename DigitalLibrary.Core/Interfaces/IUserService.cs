using DigitalLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateUserAsync(string name, string email, string password, string role = "User");
        Task<User?> ValidateUserAsync(string email, string password);
        string HashPassword(User user, string password);

    }
}
