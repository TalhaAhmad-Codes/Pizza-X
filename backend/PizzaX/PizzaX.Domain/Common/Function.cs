namespace PizzaX.Domain.Common
{
    public static class Function
    {
        public static string? Simplify(string? str, bool toLower = false)
        {
            if (str is null) return null;

            var result = str.Trim();

            return toLower ? result.ToLower() : result;
        }

        public static string ToCapitalize(string str)
        {
            var result = "";

            if (str.Length > 0)
            {
                result += char.ToUpper(str[0]);

                if (result.Length > 1)
                    result += str.Substring(1).ToLower();
            }

            return result;
        }
    }
}
