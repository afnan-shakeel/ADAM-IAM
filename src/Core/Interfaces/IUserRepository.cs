

using Application.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<UserDto> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetByUsernameAsync(string username);
    }
}