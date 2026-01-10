using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos
{
    // Update username
    public sealed class UserUpdateUsernameDto : BaseDto
    {
        // Data field
        public string Username { get; init; }
    }

    // Update email
    public sealed class UserUpdateEmailDto : BaseDto
    {
        // Data fields
        public string Password { get; init; }
        public string Email { get; init; }
    }

    // Update password
    public sealed class UserUpdatePasswordDto : BaseDto
    {
        // Data fields
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
