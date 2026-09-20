namespace GestaoDeChamados_Domain.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void UpdateProfile(string name, string email)
        {
            Name = name;
            Email = email;
            UpdateTimestamp();
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
            UpdateTimestamp();
        }
    }
}