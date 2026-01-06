using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects
{
    public sealed class Password
    {
        // Attributes
        public int Length { get; }
        public string Hash { get; }
        public readonly int LengthLimit = 8;

        // Constructor
        public Password(string password)
        {
            // Guard against invalid values
            Guard.AgainstNullOrWhitespace(password, nameof(Password));
            Guard.AgainstLowerLengthLimit(password, LengthLimit, nameof(Password));

            // Assigning values
            Length = password.Length;
            Hash = ToHash(password);
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
