using System.Text;

namespace Phoneword
{
    static class PhonewordTranslator
    {
        private static readonly string[] digits =
        {
            "ABC", "DEF", "GHI", "JKL", "MNO",
            "PQRS", "TUV", "WXYZ"
        };

        static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();

            foreach (var character in raw)
            {
                if (" -0123456789".Contains(character))
                {
                    newNumber.Append(character);
                }
                else
                {
                    var result = TranslateToNumber(character);

                    if (result != null)
                    {
                        newNumber.Append(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char character)
        {
            return keyString.IndexOf(character) >= 0;
        }

        static int? TranslateToNumber(char character)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(character))
                {
                    return 2 + i;
                }
            }

            return null;
        }
    }
}
