using System.Collections;
using System.Text.RegularExpressions;

namespace KOS.Core.Constants
{
    public static class RegularEx
    {
        public static bool IsNumeric(string num)
        {
            var regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(num);
        }

        public static bool IsString(string chr)
        {
            var regex = new Regex(@"^[A-Za-z\s]+$");
            return regex.IsMatch(chr);
        }

        public static bool IsSafePassw(string chr)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,32}$");
            return regex.IsMatch(chr);
        }
        public static bool IsNullOrEmpty(this IEnumerable source)
        {
            if (source != null)
            {
                foreach (object obj in source)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsNullOrEmpty<T>(object any)
        {
            throw new NotImplementedException();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source != null)
            {
                foreach (T obj in source)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
