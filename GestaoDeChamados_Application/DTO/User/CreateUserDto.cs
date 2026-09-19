using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeChamados_Application.DTO.User
{
    public record CreateUserDto(
        string Name,
        string Email,
        string Password
    );
}
