using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.User;
using PizzaX.Domain.ValueObjects.User;

namespace PizzaX.Domain.Entities
{
    public sealed class User : AuditableEntity
    {
        // Attributes
        public byte[]? ProfilePic { get; private set; } = null;
        public string Username {  get; private set; }
        public Email Email {  get; private set; }
        public Password Password { get; private set; }
        public Role UserRole { get; private set; }

        // Constructors
        private User() { }

        private User(string username, string email, string password, Role userRole)
        {
            // Guard against invalid values
            Guard.AgainstNullOrWhitespace(username, nameof(Username));
            Guard.AgainstNullOrWhitespace(password, nameof(Password));
            Guard.AgainstMinStringLength(password, 8, nameof(Password));

            // Asigning values
            Username = username;
            Email = Email.Create(email);
            Password = Password.Create(password);
            UserRole = userRole;
        }

        // Method - Create a new object
        public static User Create(string username, string email, string password, Role userRole)
            => new(username, email, password, userRole);

        /*******************************************/
        /* Methods - Change properties of the User */
        /*******************************************/

        // Update profile pic
        public void UpdateProfilePic(byte[]? profilePic = null)
        {
            ProfilePic = profilePic;
            MarkUpdated();
        }

        // Update email address
        public void UpdateEmail(string password, string email)
        {
            // Rule: For security concern, the user must enter his password to change his email address.
            Guard.AgainstPasswordMismatch(password, Password.Hash);

            Email = Email.Create(email);

            MarkUpdated();
        }

        // Update username
        public void UpdateUsername(string username)
        {
            Guard.AgainstNullOrWhitespace(username, nameof(Username));

            Username = username;

            MarkUpdated();
        }

        // Update password
        public void UpdatePassword(string oldPassword, string newPassword)
        {
            // Rule: For security concern, the user must enter old password to change his current password.
            Guard.AgainstPasswordMismatch(oldPassword, Password.Hash);

            Password = Password.Create(newPassword);

            MarkUpdated();
        }

        // Update role
        public void UpdateUserRole(Role userRole, bool isVerifiedByAdmin)
        {
            // Rule: For security concern, the admin must approve the user to change his role
            Guard.AgainstUnauthorizedByAdmin(isVerifiedByAdmin);

            UserRole = userRole;
        }
    }
}
