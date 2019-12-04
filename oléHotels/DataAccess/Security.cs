using System.Text;

namespace OleHotels.Models
{
    public static class Security
    {
        private static int mod = 26;
        private static string key = "ab";

        public static string Encrypt(this string text)
        {
            var result = new StringBuilder();

            for(var i = 0; i < text.Length; i++)
            {
                result.Append(((LetrDown(text[i]) + LetrDown(key[0])) % mod) + Ascii('a'));
            }

            return result.ToString();
        }

        private static int Ascii(char c)
        {
            return (int)c;
        }

        private static char ToChar(int i)
        {
            return (char)i;
        }

        private static int LetrDown(char s) {
            var avar = Ascii(s);
            var aa = Ascii('a');
            var a_A = Ascii('A');

            if ((avar - aa) < 26 && (avar - aa) >= 0)
                return avar - aa;

            if ((avar - a_A) < 26 && (avar - a_A) >= 0)
                return avar - a_A;

            return Ascii(s);
}
    }
}