using GestaoDeChamados_Domain.Entity;


namespace GestaoDeChamados_Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
