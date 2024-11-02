using Application.Interfaces;
using Application.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Exceptions;
using System.Runtime.InteropServices;
using AutoMapper;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> RegisterUserAsync(User user)
        {
            var userDto = await _userRepository.AddAsync(user);
            return userDto;
        }
        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            var userDto = await _userRepository.GetByUsernameAsync(username);
            if (userDto == null)
            {
                throw new NotFoundException("User not found.");
            }
            var user = _mapper.Map<UserDto>(userDto);
            return user;
        }


    }
}