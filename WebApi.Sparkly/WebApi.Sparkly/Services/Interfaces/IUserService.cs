using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Sparkly.Models;

namespace WebApi.Sparkly.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task<User> Authenticate(string email, string password);
}
