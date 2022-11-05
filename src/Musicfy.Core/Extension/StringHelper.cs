using System.Text.RegularExpressions;

namespace Musicfy.Core.Extension
{
    public static class StringHelper
    {
        public static string RemoveWhiteSpace(string str)
        {
            return Regex.Replace(str, @"\s", "");
        }
    }
}
