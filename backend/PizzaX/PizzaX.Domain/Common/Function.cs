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
            bool canCapitalize = true;
            int i = 0;

            while (i < str.Length)
            {
                result += (canCapitalize) ? char.ToUpper(str[i]) : char.ToLower(str[i]);
                i++;

                if (i > 0)
                    canCapitalize = str[i - 1] == ' ';
            }

            return result;
        }
    }
}
