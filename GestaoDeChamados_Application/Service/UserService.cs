using GestaoDeChamados_Application.DTO.User;
using GestaoDeChamados_Application.Exceptions;
using GestaoDeChamados_Application.Interface;
using GestaoDeChamados_Domain.Entity;
using GestaoDeChamados_Domain.Interface;

namespace GestaoDeChamados_Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserDto dto)
        {
            var user = new User(dto.Name, dto.Email, dto.Password);

            await _userRepository.AddUserAsync(user);

            return new UserResponseDto(
                user.Id,
                user.Name,
                user.Email,
                user.CreatedAt,
                user.UpdatedAt
            );
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var deletedUser = await _userRepository.GetUserByIdAsync(id);

            if (deletedUser == null)
            {
                throw new NotFoundException("Usuario não encontrado");
            }

            await _userRepository.DeleteUserAsync(deletedUser.Id);
        }

        public async Task<UserResponseDto> UpdateUserAsync(Guid id, UpdateUserDto user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                throw new NotFoundException("Usuario não encontrado");
            }

            existingUser.UpdateProfile(user.Name, user.Email);
            existingUser.ChangePassword(user.Password);

            await _userRepository.UpdateUserAsync(existingUser);

            return new UserResponseDto(
                existingUser.Id,
                existingUser.Name,
                existingUser.Email,
                existingUser.CreatedAt,
                existingUser.UpdatedAt
            );
        }
    }

}
