using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Napas.Portal.Business
{
    public static class Utilities
    {
        public static string ConvertToUnsign(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
                string temp = str.Normalize(NormalizationForm.FormD);
                return regex.Replace(temp, String.Empty)
                            .Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ", "-").Replace("/", "-").ToLower();
            }

            return string.Empty;
        }

        public static string SplitText(string str, int numWord)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            string newText = string.Empty;
            var s = str.Split(' ');
            if (s.Length < numWord)
            {
                return str;
            }

            for (int i = 0; i < numWord; i++)
            {
                newText += s[i] + " ";
            }

            return newText + "...";
        }
    }
}