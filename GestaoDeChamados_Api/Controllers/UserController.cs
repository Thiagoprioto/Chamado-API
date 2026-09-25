using FluentValidation;
using GestaoDeChamados_Application.DTO.User;
using GestaoDeChamados_Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeChamados_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserDto> _validator;

        public UserController(IUserService userService, IValidator<CreateUserDto> validator)
        {
            _userService = userService;
            _validator = validator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var validateUser = await _validator.ValidateAsync(dto);

            if (!validateUser.IsValid)
            {
                return BadRequest(validateUser.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            var createdUser = await _userService.CreateUserAsync(dto);


            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser() 
        {
            var getAllUser = await _userService.GetAllUserAsync();

            return Ok(getAllUser);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateUserDto dto)
        {
            var updateUser = await _userService.UpdateUserAsync(id, dto);

            if (updateUser is null)
            {
                return NotFound(new { mensagem = $"Usuário com ID {id} não foi encontrado." });
            }

            return Ok(updateUser);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id) 
        {
            var findById = await _userService.GetUserByIdAsync(id);
            
            if(findById == null)
            {
                return NotFound("Usuario não encontrado");
            }
            return NoContent();
        }
    }
}
