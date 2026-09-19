namespace GestaoDeChamados_Domain.Entity
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void UpdateProfile(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}