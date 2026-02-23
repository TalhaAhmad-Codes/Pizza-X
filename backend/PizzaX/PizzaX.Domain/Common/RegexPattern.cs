namespace PizzaX.Domain.Common
{
    public static class RegexPattern
    {
        public static Pattern Email => new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
        );

        public static Pattern ContactNumber => new(
            @"^(?:\+92|92|0)3\d{9}$",
            "It can only contain numbers in the format of +923XXYYYYYYY, 923XXYYYYYYY or 03XXYYYYYYY."
        );
        public static Pattern CNIC => new(
            @"^\d{5}-\d{7}-\d{1}$",
            "It can only contain the formate of XXXXX-YYYYYYY-Z."
        );

        public static Pattern Username => new(
            @"^[A-Za-z][A-Za-z0-9]{2,19}$",
            "It can only contain alphanumeric characters, and start with an alphabet, with a length of 3-20 characters."
        );
        
        public static Pattern SingleName => new(
            @"^[A-Za-z]+$",
            "It can only contain alphabets."
        );
        
        public static Pattern FullName => new(
            @"^[A-Za-z]+(?: [A-Za-z]+)*$",
            "It can only contain alphabets and a single space between them."
        );

        public static Pattern ProductName => FullName;
        public static Pattern DealName => new(
            @"^[A-Za-z0-9]+(?:\s[A-Za-z0-9]+)*$",
            "It can only contain alphabets and digits and also single whitespace between them."
        );
    }

    public struct Pattern
    {
        public String Value { get; }
        public string? Message { get; }

        public Pattern(String value, string? message = null)
        {
            if (string.IsNullOrWhiteSpace(message) && message != null)
                throw new DomainException("Regex pattern message can't be empty / whitespace.");

            if (String.IsNullOrWhiteSpace(value))
                throw new DomainException("Regex pattern can't be empty / whitespace.");

            Value = value;
            Message = message;
        }
    }
}
