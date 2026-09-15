using Chamados_Domain.Entity;


namespace Chamados_Domain.Interface
{
    public interface IUser
    {
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(Guid id);
    }
}
