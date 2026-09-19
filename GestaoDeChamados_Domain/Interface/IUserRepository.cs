using GestaoDeChamados_Domain.Entity;


namespace GestaoDeChamados_Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(Guid id);
    }
}
