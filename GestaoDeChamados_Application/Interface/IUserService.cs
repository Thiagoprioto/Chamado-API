using GestaoDeChamados_Application.DTO.User;
using GestaoDeChamados_Domain.Entity;

namespace GestaoDeChamados_Application.Interface
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(CreateUserDto user);
        Task<UserResponseDto> UpdateUserAsync(Guid id, UpdateUserDto user);
        Task DeleteUserAsync(Guid id);
    }
}
