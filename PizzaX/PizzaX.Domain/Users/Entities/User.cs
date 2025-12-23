using PizzaX.Domain.Common;
using PizzaX.Domain.Users.Enums;
using PizzaX.Domain.Users.ValueObjects;

namespace PizzaX.Domain.Users.Entities
{
    public sealed class User : BaseEntity
    {
        // Attributes
        public byte[]? ProfilePic { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Email Email { get; private set; }
        public UserRole? Role { get; private set; }
        public bool IsActive { get; private set; }

        // Constructors
        private User() { }

        private User(string username, string password, Email email, UserRole? role, bool isActive)
        {
            // Validation Check
            Guard.AgainstNull(username, nameof(Username));
            Guard.AgainstNull(password, nameof(Password));

            // Assigning values
            Username = username;
            Password = password;
            Email = email;
            Role = role;
            IsActive = isActive;
        }

        // Method - Create a new user
        public static User Create(string username, string password, Email email, UserRole? role, bool isActive) 
            => new(username, password, email, role, isActive);

        // Method - Change password
        public void ChangePassword(string newPass)
        {
            Guard.AgainstNull(newPass, nameof(Password));
            Password = newPass;
            MarkUpdated();
        }

        // Method - Update profile picture
        public void UpdateProfilePic(byte[]? picture)
        {
            ProfilePic = picture;
            MarkUpdated();
        }

        // Method - Update role of the user
        public void UpdateRole(UserRole? newRole)
        {
            Role = newRole;
            MarkUpdated();
        }

        // Method - Update to active
        public void UpdateToActive()
        {
            IsActive = true;
            MarkUpdated();
        }

        // Method - Update to in-active
        public void UpdateToInActive()
        {
            IsActive = false;
            MarkUpdated();
        }
    }
}
