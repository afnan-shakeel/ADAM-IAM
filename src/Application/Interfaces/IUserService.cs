using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(User user);
        Task<UserDto> GetByUsernameAsync(string username);
        // Task AssignRoleToUserAsync(Guid userId, Guid roleId);
    }
}