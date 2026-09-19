
namespace GestaoDeChamados_Application.DTO.User
{
    public record UserResponseDto(
        Guid Id,
        string Name,
        string Email,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
