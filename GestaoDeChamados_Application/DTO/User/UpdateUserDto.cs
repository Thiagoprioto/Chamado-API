
namespace GestaoDeChamados_Application.DTO.User
{
    public record UpdateUserDto(
        string Name,
        string Email,
        string Password,
        DateTime UpdatedAt
    );
}
