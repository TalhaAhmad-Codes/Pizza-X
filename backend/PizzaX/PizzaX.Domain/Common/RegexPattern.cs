namespace PizzaX.Domain.Common
{
    public static class RegexPattern
    {
        public static String Email => @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public static String ContactNumber => @"^(?:\+92|92|0)3\d{9}$";
        public static String CNIC => @"^\d{5}-\d{7}-\d{1}$";
        public static String SingleName => @"^[A-Za-z]+$";
        public static String FullName => @"^[A-Za-z]+(?: [A-Za-z]+)*$";
        public static String CategoryName => FullName;
    }
}
