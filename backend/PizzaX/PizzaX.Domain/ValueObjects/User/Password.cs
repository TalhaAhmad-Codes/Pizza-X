using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.User
{
    public sealed class Password
    {
        // Attributes
        public int Length { get; }
        public string Hash { get; }
        public readonly int MinLengthLimit = 8;

        // Constructor
        private Password() { }
        private Password(string password)
        {
            // Guard against invalid values
            Guard.AgainstNullOrWhitespace(password, nameof(Password));
            Guard.AgainstMinStringLength(password, MinLengthLimit, nameof(Password));

            // Assigning values
            Length = password.Length;
            Hash = ToHash(password.Trim());
        }

        // Method - Create a new object
        public static Password Create(string password)
            => new(password);

        // Method - Convert to string
        public override string ToString()
            => Hash;

        // Method - Hash a normal password
        private static string ToHash(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        // Method - Check if two passwords are same
        public static bool Verify(string password, string hash)
            => BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
