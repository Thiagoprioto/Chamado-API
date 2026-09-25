using GestaoDeChamados_Application.DTO.User;
using GestaoDeChamados_Domain.Entity;

namespace GestaoDeChamados_Application.Interface
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(CreateUserDto user);
        Task<IEnumerable<UserResponseDto>> GetAllUserAsync();
        Task<UserResponseDto> GetUserByIdAsync(Guid id);
        Task<UserResponseDto> UpdateUserAsync(Guid id, UpdateUserDto user);
        Task DeleteUserAsync(Guid id);
    }
}
